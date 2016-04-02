using System;
using NUnit.Framework;
using WatiN.Core;
using System.Text.RegularExpressions;

namespace Tests
{
    [TestFixture]
    public class MainTest : MainProgram
    {
        [Test]
        public void Test1()
        {
            IE ie = new IE("http://www.yu.edu.jo/");
            foreach (Button but in ie.Buttons)
            {
                try
                {
                    but.Click();
                }
                catch (Exception ex)
                {
                }
            }
            
           
          //  ie.GoTo("http://www.yu.edu.jo/");
            ie.Button(Find.ByValue("Top")).Click();
            ie.Button(Find.ByValue("form2")).Click();
            ie.Button(Find.ByValue("votid")).Click();
            ie.Button(Find.ByValue("task_button")).Click();
            ie.Button(Find.ByValue("option")).Click();
            ie.Button(Find.ByValue("task")).Click();
            ie.Button(Find.ByValue("id")).Click();
            
            ie.TextField(Find.ById("TextBox1")).TypeText("rabbi");
            ie.TextField(Find.ById("TextBox2")).TypeText("rabbi");
            ie.Button(Find.ById("Button1")).Click();
            Assert.IsFalse(ie.ContainsText("Unknown User"));
        }

        [Test]
        public void CheckLogin()
        {
            ie.GoTo("http://localhost:2434/");
            ie.TextField(Find.ById("TextBox1")).TypeText("rabbi");
            ie.TextField(Find.ById("TextBox2")).TypeText("rabbi");
            ie.Button(Find.ById("Button1")).Click();
            Assert.IsTrue(ie.ContainsText("Welcome Rabbi"));
        }
    }
}
