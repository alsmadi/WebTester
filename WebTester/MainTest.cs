using System;
using NUnit.Framework;
using WatiN.Core;
using System.Text.RegularExpressions;
using WebTester;
using System.Windows.Forms;
using System.Collections;

namespace WebTester
{
    [TestFixture]
    public class MainTest 
    {
        public static Hashtable links;
        WebTester tester = new WebTester();
        [Test]
        public void Test1(string URL)
        {
            IE ie = new IE(URL);
            links = new Hashtable();
            MessageBox.Show("The total number of links in this page = " + ie.Links.Length);
            for (int il = 0; il <= ie.Links.Length; il++)
            {
               
                    
                try
                {
                    if (ie.Links[il].Text != null && ie.Links[il].Url != null)
                        links.Add(ie.Links[il].Text, ie.Links[il].Url);
                    ie.Links[il].Click();
                }
                catch (Exception ex)
                {
                }
            }

           
            
           
          //  ie.GoTo("http://www.yu.edu.jo/");
           /* ie.Button(Find.ByValue("Top")).Click();
            ie.Button(Find.ByValue("form2")).Click();
            ie.Button(Find.ByValue("votid")).Click();
            ie.Button(Find.ByValue("task_button")).Click();
            ie.Button(Find.ByValue("option")).Click();
            ie.Button(Find.ByValue("task")).Click();
            ie.Button(Find.ByValue("id")).Click();
            
            ie.TextField(Find.ById("TextBox1")).TypeText("rabbi");
            ie.TextField(Find.ById("TextBox2")).TypeText("rabbi");
            ie.Button(Find.ById("Button1")).Click();
            Assert.IsFalse(ie.ContainsText("Unknown User")); */
        }

        [Test]
       // public void Test1(string URL);
        public void Test2(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.CheckBox chk in ie.CheckBoxes)
            {
                try
                {
                    links.Add(chk.OuterText,chk.OuterHtml);
                    chk.Click();

                }
                catch (Exception ex)
                {
                }
            }
            //ie.GoTo("http://localhost:2434/");
            //ie.TextField(Find.ById("TextBox1")).TypeText("rabbi");
            //ie.TextField(Find.ById("TextBox2")).TypeText("rabbi");
            //ie.Button(Find.ById("Button1")).Click();
            //Assert.IsTrue(ie.ContainsText("Welcome Rabbi"));
        }
        [Test]
        public void Test3(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (Element el in ie.Elements)
            {
                
                try
                {
                    links.Add(el.OuterText,el.OuterHtml);
                    el.Click();
                }
                catch (Exception ex)
                {
                }
            }
           
        }
        [Test]
        public void Test4(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (FileUpload fa in ie.FileUploads)
            {

                try
                {
                    links.Add(fa.OuterText, fa.OuterHtml);
                    fa.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test5(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (Frame fr in ie.Frames)
            {

                try
                {
                    links.Add(fr.Name, fr.Name);
                   // fr..Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test6(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (HtmlDialog hd in ie.HtmlDialogs)
            {

                try
                {
                    links.Add(hd.Uri.AbsoluteUri, hd.Uri.AbsolutePath);
                   // hd.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test8(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (Image im in ie.Images)
            {

                try
                {
                    links.Add(im.OuterText, im.OuterHtml);
                    im.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test9(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.Label lb in ie.Labels)
            {

                try
                {
                    links.Add(lb.OuterText, lb.OuterHtml);
                    lb.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test10(string URL)
        {

            links = new Hashtable();

            IE ie = new IE(URL);
            foreach (WatiN.Core.Button but in ie.Buttons)
            {
                try
                {
                    links.Add(" A button", but.Text);
                    //  but.Click();
                    //   tester.lstvWebSiteWebSite.Items.Add(but.OuterHtml);

                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }
        [Test]
        public void Test11(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (Para pr in ie.Paras)
            {

                try
                {
                    links.Add(pr.OuterText, pr.OuterHtml);
                    pr.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test12(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.RadioButton rb in ie.RadioButtons)
            {

                try
                {
                    links.Add(rb.OuterText, rb.OuterHtml);
                    rb.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test13(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.SelectList sl in ie.SelectLists)
            {

                try
                {
                    links.Add(sl.OuterText, sl.OuterHtml);
                    sl.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test14(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.Span sp in ie.Spans)
            {

                try
                {
                    links.Add(sp.OuterText, sp.OuterHtml);
                    sp.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test15(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.TableRow tr in ie.TableRows)
            {

                try
                {
                    links.Add(tr.OuterText, tr.OuterHtml);
                    tr.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        [Test]
        public void Test16(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.TextField tf in ie.TextFields)
            {

                try
                {
                    links.Add(tf.OuterText, tf.OuterHtml);
                    tf.Click();
                }
                catch (Exception ex)
                {
                }
            }

        }
        
        [Test]
        public void Test7(string URL)
        {

            IE ie = new IE(URL);
            links = new Hashtable();
            foreach (WatiN.Core.Form form in ie.Forms)
            {
                try
                {
                    links.Add(form.OuterText, form.Name);
                    form.Click();
                }
                catch (Exception ex)
                {
                }
            }
            //ie.GoTo("http://localhost:2434/");
            //ie.TextField(Find.ById("TextBox1")).TypeText("rabbi");
            //ie.TextField(Find.ById("TextBox2")).TypeText("rabbi");
            //ie.Button(Find.ById("Button1")).Click();
            //Assert.IsTrue(ie.ContainsText("Welcome Rabbi"));
        }
    }
}
