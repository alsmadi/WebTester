using System;
using NUnit.Framework;
using WatiN.Core;
using System.Text.RegularExpressions;
using Tests;

namespace Tests
{
    public abstract class MainProgram
    {
        protected IE ie = null;

        [TestFixtureSetUpAttribute]
        public void SetUp()
        {
            ie = new IE();
        }

        [STAThread]
        static void Main(string[] args)
        {
            // Open a new Internet Explorer window and
            // goto the google website.
            MainTest t1 = new MainTest();
            t1.Test1();
            //IE ie1 = new IE("http://www.yu.edu.jo/");
            IE ie = new IE("http://www.google.com");

            // Find the search text field and type Watin in it.
            ie.TextField(Find.ByName("q")).TypeText("WatiN");

            // Click the Google search button.
            ie.Button(Find.ByValue("Google Search")).Click();

            // Uncomment the following line if you want to close
            // Internet Explorer and the console window immediately.
            //ie.Close();
        }
    }  
}
