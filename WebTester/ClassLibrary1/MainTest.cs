using System;
using NUnit.Framework;
using WatiN.Core;
using System.Text.RegularExpressions;
using WebTester;
using System.Windows.Forms;

namespace Testing
{
    [TestFixture]
    public class MainTest 
    {
        WebTester.WebTester tester = new WebTester.WebTester();
        [Test]
        public void Test1(string URL)
        {
            
            IE ie = new IE(URL);
            foreach (WatiN.Core.Button but in ie.Buttons)
            {
                try
                {
                    but.Click();
                 //   tester.lstvWebSiteWebSite.Items.Add(but.OuterHtml);
                    
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
            foreach (WatiN.Core.CheckBox chk in ie.CheckBoxes)
            {
                try
                {

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
            foreach (Element el in ie.Elements)
            {
                
                try
                {
                    el.Click();
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
        public void Test4(string URL)
        {

            IE ie = new IE(URL);
            foreach (WatiN.Core.Form form in ie.Forms)
            {
                try
                {
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
