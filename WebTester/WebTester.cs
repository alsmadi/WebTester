using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Collections;
//using Testing;

namespace WebTester
{
    public partial class WebTester : Form
    {
        protected Regex m_rxBaseHref;

        protected Regex m_rxHref;
        protected Regex m_rxFrame;
        protected Regex m_rxIframe;
        protected Regex m_rxArea;

        protected List<string> m_strListUrlsAdded;
        protected List<string> m_strListUrlsFollowed;

        protected Thread m_thReadUrls = null;

        protected int CountNavegate;

        public WebTester()
        {
            InitializeComponent();

            CountNavegate = 0;

            RegexOptions rxOpt = RegexOptions.Singleline |
                                    RegexOptions.Compiled |
                                    RegexOptions.IgnoreCase;

            //We have to create our regular expression for parsing hyperlinks, base hrefs an so on
            m_rxHref = new Regex("<a[^>]*href=(\"|')(.*?)\\1[^>]*>(.*?)</a>", rxOpt);
            m_rxFrame = new Regex("<frame[^>]*src=(\"|')(.*?)\\1[^>]*>", rxOpt);
            m_rxIframe = new Regex("<iframe[^>]*src=(\"|')(.*?)\\1[^>]*>", rxOpt);
            m_rxArea = new Regex("<area[^>]*href=(\"|')(.*?)\\1[^>]*>", rxOpt);
            m_rxBaseHref = new Regex("<base[^>]* href=(\"|')(.*?)\\1[^>]*>", rxOpt);
        }

        struct SReadUrlsThreadParams
        {
            public string strUrl;
            public string strStartBase;
            public List<string> strListUrlsAdded;
            public List<string> strListUrlsFollowed;
            public int iMaxDepth;
        }

        protected delegate void DoDebugOutputDelegate(string strText);
        protected void DoDebugOutput(string strText)
        {
            //if (tbDebugOutput.InvokeRequired)
            //{
            //    tbDebugOutput.BeginInvoke(new DoDebugOutputDelegate(DoDebugOutput),
            //        new object[] { strText });
            //}
            //else
            //{
            //    tbDebugOutput.Text += DateTime.Now.ToLongTimeString() + ": " + strText + "\r\n";
            //    tbDebugOutput.SelectionStart = tbDebugOutput.Text.Length;
            //    tbDebugOutput.ScrollToCaret();
            //}
        }

        protected delegate void EnableReadUrlButtonDelegate();
        protected void EnableReadUrlButton()
        {
            if (btnURL.InvokeRequired)
            {
                btnURL.BeginInvoke(new EnableReadUrlButtonDelegate(EnableReadUrlButton));
            }
            else
            {
                btnURL.Enabled = true;
            }
        }

        protected void StartReadUrls(object objThreadParams)
        {
            SReadUrlsThreadParams sParams = (SReadUrlsThreadParams)objThreadParams;

            ReadUrls(sParams.strUrl, sParams.strStartBase, ref sParams.strListUrlsAdded,
                ref sParams.strListUrlsFollowed, sParams.iMaxDepth, 0);

            m_thReadUrls = null;
            EnableReadUrlButton();
        }

        protected delegate void AddListViewItemDelegate(ListViewItem lvi);
        protected void AddListViewItem(ListViewItem lvi)
        {
            if (lstvURL.InvokeRequired)
            {
                lstvURL.BeginInvoke(new AddListViewItemDelegate(AddListViewItem),
                    new object[] { lvi });
            }
            else
            {
                lstvURL.Items.Add(lvi);
            }
        }

        protected void ReadUrls(string strURL, string strStartBase,
                        ref List<string> strUrlsAdded,
                        ref List<string> strUrlsFollowed,
                        int iMaximumDepth,
                        int iCurrentDepth)
        {
            DoDebugOutput(string.Format("Entering ReadUrls; URL: {0}; StartBase: {1};" +
                "Depth: {2}", strURL, strStartBase, iCurrentDepth));

            //Increase the depth. If we reach the maximum depth: return
            //if (++iCurrentDepth == iMaximumDepth)
            //{
            //    DoDebugOutput("Reached Maximum Depth - Return");
            //    return;
            //}

            //No we create the WebRequest and get the response. If something fails
            //we return

            HttpWebRequest req = null;

            try
            {
                req = HttpWebRequest.Create(strURL) as HttpWebRequest;
            }
            catch (Exception ex)
            {
                DoDebugOutput(string.Format("Creating Web Request Failed; URL: {0}; Exception: {1}",
                    strURL, ex.Message));
            }

            if (req == null)
            {
                return;
            }

            req.Method = "GET";

            HttpWebResponse res = null;
            try
            {
                res = req.GetResponse() as HttpWebResponse;
            }
            catch (Exception ex)
            {
                DoDebugOutput(string.Format("Getting Response Failed; URL: {0}; Exception: {1}",
                    strURL, ex.Message));
            }

            if (res != null && res.StatusCode != HttpStatusCode.OK)
            {
                DoDebugOutput(string.Format("Response Status Code not ok; URL: {0}; Code: {1}",
                    strURL, res.StatusCode));
            }

            if (res == null || res.StatusCode != HttpStatusCode.OK)
            {
                return;
            }

            Stream s = res.GetResponseStream();

            StreamReader sr = new StreamReader(s);

            //Read the whole content of the response stream into a string
            string strHTML = sr.ReadToEnd();

            DoDebugOutput(string.Format("HTML Length: {0}",
                strHTML.Length));

            sr.Close();
            sr.Dispose();
            sr = null;

            s.Close();
            s.Dispose();
            s = null;

            int iPos, iPos2;

            //We need the base to follow relative URLs
            string strBase = req.Address.AbsoluteUri;

            //If the base contains a query string we remove that string
            //because we don't need it.
            iPos = strBase.IndexOf('?');
            if (iPos > -1)
            {
                strBase = strBase.Substring(0, iPos);
            }

            //Assure that the base ends with a slash
            if (strBase[strBase.Length - 1] != '/')
            {
                iPos = strBase.LastIndexOf('/');
                if (iPos < 0)
                {
                    return;
                }

                strBase = strBase.Substring(0, iPos + 1);
            }

            iPos = strBase.IndexOf("://");
            if (iPos < 0)
            {
                return;
            }

            iPos = strBase.IndexOf('/', iPos + 3);
            if (iPos < 0)
            {
                return;
            }

            //We need the base host URL for hyperlinks that start with a slash
            string strBaseHostUrl = strBase.Substring(0, iPos + 1);

            //Test if the HTML contains a base href
            Match matchBaseHref = m_rxBaseHref.Match(strHTML);
            if (matchBaseHref.Success)
            {
                string strHtmlBase = matchBaseHref.Groups[2].Value.Trim();
                if (strHtmlBase.StartsWith("/"))
                {
                    strBase = strBaseHostUrl + strHtmlBase.Substring(1);
                }
                else
                {
                    strBase = strHtmlBase;
                }
            }

            DoDebugOutput(string.Format("Base: {0}", strBase));

            //This dictionary contains all hyperlinks and their
            //associated "texts" (anything between <a> and </a>)
            Dictionary<string, string> dictHrefs = new Dictionary<string, string>();

            MatchCollection matchesHref = m_rxHref.Matches(strHTML);
            AddHrefMatches(matchesHref, ref dictHrefs);

            MatchCollection matchesFrame = m_rxFrame.Matches(strHTML);
            AddHrefMatches(matchesFrame, ref dictHrefs);

            MatchCollection matchesIframe = m_rxIframe.Matches(strHTML);
            AddHrefMatches(matchesIframe, ref dictHrefs);

            MatchCollection matchesArea = m_rxArea.Matches(strHTML);
            AddHrefMatches(matchesArea, ref dictHrefs);

            DoDebugOutput(string.Format("Total number of href regex matches: {0}",
                dictHrefs.Count));

            //Now we iterate through all Hyperlinks we found
            foreach (string strUrlFound in dictHrefs.Keys)
            {
                string strUrlNew = strUrlFound;

                //Skip this links if it starts with ftp://, news://, mailto:,
                //javascript:
                if (IsAbsoluteUrl(strUrlNew) && !IsHttpUrl(strUrlNew))
                {
                    DoDebugOutput(string.Format("Skipping URL: {0}", strUrlNew));
                    continue;
                }

                //if this isn't an absolute URL
                if (!IsHttpUrl(strUrlNew))
                {
                    if (strUrlNew.StartsWith("/"))
                    {
                        strUrlNew = strBaseHostUrl + strUrlNew.Substring(1);
                    }
                    else
                    {
                        strUrlNew = strBase + strUrlNew;
                    }
                }

                //Now we remove all parent paths
                while ((iPos = strUrlNew.IndexOf("../")) > -1)
                {
                    iPos2 = strUrlNew.Substring(0, iPos).LastIndexOf('/');
                    iPos2 = strUrlNew.Substring(0, iPos2).LastIndexOf('/');

                    strUrlNew = strUrlNew.Substring(0, iPos2) +
                        "/" + strUrlNew.Substring(iPos + 3);
                }

                //if the URL doesn't start with our starting base
                //(the address we entered into our textbox) then
                //skip this
                if (!strUrlNew.StartsWith(strStartBase))
                {
                    DoDebugOutput(string.Format("URL doesn't start with Start Base: {0}",
                        strUrlNew));
                    continue;
                }

                //If we haven't added the URL yet to our listview do it now
                if (!strUrlsAdded.Contains(strUrlNew))
                {
                    DoDebugOutput(string.Format("Adding URL: {0}", strUrlNew));

                    ListViewItem lvi = new ListViewItem(new string[]{
                        strUrlNew,
                        dictHrefs[strUrlFound]
                    });
                    AddListViewItem(lvi);

                    strUrlsAdded.Add(strUrlNew);
                }
                else
                {
                    DoDebugOutput(string.Format("URL already added: {0}", strUrlNew));
                }

                //Follow this URL if not alreay done
                if (!strUrlsFollowed.Contains(strUrlNew))
                {
                    DoDebugOutput(string.Format("Following URL: {0}", strUrlNew));

                    strUrlsFollowed.Add(strUrlNew);
                    ReadUrls(strUrlNew, strStartBase,
                        ref strUrlsAdded, ref strUrlsFollowed,
                        iMaximumDepth, iCurrentDepth);
                }
                else
                {
                    DoDebugOutput(string.Format("URL already followed: {0}", strUrlNew));
                }
            }
        }

        protected void AddHrefMatches(MatchCollection matches,
                        ref Dictionary<string, string> dictHrefs)
        {
            foreach (Match match in matches)
            {
                if (!dictHrefs.ContainsKey(match.Groups[2].Value))
                {
                    if (match.Groups.Count > 3)
                    {
                        dictHrefs.Add(match.Groups[2].Value,
                                        match.Groups[3].Value);
                    }
                    else
                    {
                        dictHrefs.Add(match.Groups[2].Value, "");
                    }
                }
            }
        }

        private void btnURL_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_thReadUrls != null)
                {
                    m_thReadUrls.Abort();
                    m_thReadUrls.Join();
                }

                this.Cursor = Cursors.WaitCursor;

                //Clear the counter
                CountNavegate = 0;
                //Clear existing URLs
                lstvURL.Items.Clear();
                //tbDebugOutput.Clear();

                m_strListUrlsAdded = new List<string>();
                m_strListUrlsFollowed = new List<string>();

                SReadUrlsThreadParams sParams = new SReadUrlsThreadParams();
                //sParams.iMaxDepth = (int)numMaxDepth.Value;
                sParams.strListUrlsAdded = m_strListUrlsAdded;
                sParams.strListUrlsFollowed = m_strListUrlsFollowed;
                sParams.strStartBase = txtURL.Text;
                sParams.strUrl = txtURL.Text;

                btnURL.Enabled = false;

                m_thReadUrls = new Thread(new ParameterizedThreadStart(StartReadUrls));
                m_thReadUrls.Start(sParams);
            }
            catch (Exception ex)
            {
                DoDebugOutput("Reading URLs failed; Exception: " + ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        protected bool IsHttpUrl(string strUrl)
        {
            if (strUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (strUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        protected bool IsAbsoluteUrl(string strUrl)
        {
            if (strUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (strUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (strUrl.StartsWith("mailto:", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (strUrl.StartsWith("ftp://", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (strUrl.StartsWith("news://", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (strUrl.StartsWith("javascript:", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        private void WebTester_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void btnNumberofURL_Click(object sender, EventArgs e)
        {
            txtNumberURL.Text = lstvURL.Items.Count.ToString();
        }

        private void btnNewPath_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstvURL.SelectedItems.Count > 0)
                {
                    ListViewItem path = new ListViewItem();

                    path.Text = lstvURL.SelectedItems[0].Text;
                    ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                    subItem.Text = lstvURL.SelectedItems[0].SubItems[1].Text;
                    path.SubItems.Add(subItem);
                    lstvWebSite.Items.Add(path);
                    CountNavegate++;

                    string PathURL = lstvURL.SelectedItems[0].Text;
                    Process.Start("iexplore", PathURL);
                }
            }
            catch
            {
            }
        }

        private void btnNumberWebSitePath_Click(object sender, EventArgs e)
        {
            txtNumberWebSite.Text = CountNavegate.ToString();
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            int countURL = lstvURL.Items.Count;
            txtAverage.Text = ((double)CountNavegate / (double)countURL).ToString();
        }

        private void testCase1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();

            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                  t1.Test1(f1.URL);
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString()+ "  "+ etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test2(f1.URL);
            }
            IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
            while (etr.MoveNext())
            {
                lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
            }
        }

        private void testCase3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test3(f1.URL);
            }
            IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
            while (etr.MoveNext())
            {
                lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
            }
        }

        private void testCas4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test4(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test5(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test6(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test7(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test8(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test9(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test10(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test11(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test12(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test13(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test14(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase15ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test15(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }

        private void testCase16ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainTest t1 = new MainTest();
            DlgForm f1 = new DlgForm();
            if (f1.ShowDialog(this) == DialogResult.OK)
            {
                lstvWebSite.Items.Add(f1.URL);
                t1.Test16(f1.URL);
            }
            if (MainTest.links != null)
            {
                IDictionaryEnumerator etr = MainTest.links.GetEnumerator();
                while (etr.MoveNext())
                {
                    lstvWebSite.Items.Add(etr.Entry.Key.ToString() + "  " + etr.Entry.Value.ToString());
                }
            }
        }
    }
}
