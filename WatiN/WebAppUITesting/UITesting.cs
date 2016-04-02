using System.Diagnostics;
using WatiN.Core;
using NUnit.Framework;
using System;

namespace WebAppUITesting
{
    [TestFixture]
    public class UITesting
    {
        //process object 
        private Process p;

        [TestFixtureSetUpAttribute]
        public void SetUp()
        {            
            // create a new process to start the ASP.Net Development Server
            p = new Process();

            // set the initial properties 
            string path = Environment.CurrentDirectory.Replace(@"WebAppUITesting\bin", string.Empty);
            p.StartInfo.FileName = "WebDev.WebServer.EXE";
            p.StartInfo.Arguments = String.Format("/port:8080 /path:\"{0}WebApp\"", path);
            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            
            // start the process
            p.Start();
        }

        [Test]
        public void CheckIfNicknameIsNotUsed()
        {
            // create a new Internet Explorer instance pointing to the ASP.NET Development Server
            using (IE ie = new IE("http://yu.edu.jo"))
            {
                // Maximize the IE window in order to view test
                ie.ShowWindow(NativeMethods.WindowShowStyle.Maximize);

                // search for txtNickName and type "gsus" in it
                ie.TextField(Find.ById("txtNickName")).TypeText("gsus");

                // fire the click event of the button
                ie.Button(Find.ById("btnCheck")).Click();
                                
                // parse the response in order to fail the test or not 
                Assert.AreEqual(true, ie.ContainsText("The nickname is not used"));
            }            
        }

        [TestFixtureTearDownAttribute]
        public void TearDown()
        {
            // kill the ASP.NET Development Server process
            p.Kill();
        }
    }
}