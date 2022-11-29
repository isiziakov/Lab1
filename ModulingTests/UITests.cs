using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;

namespace ModulingTests
{
    //[TestClass]
    public class UITests
    {
        private WiniumDriver setup()
        {
            DesktopOptions options = new DesktopOptions { ApplicationPath = @"C:\Users\ivans\Desktop\Testing\Lab1\Lab1\bin\Debug\Lab1.exe" };
            WiniumDriverService service = WiniumDriverService.CreateDesktopService(@"C:\Users\ivans\Downloads\");
            return new WiniumDriver(service, options);
        }
        //[TestMethod]
        public void TestMethod1()
        {
            
            var driver = setup();

            var test = driver.FindElementById("textBox1");
            test.SendKeys("3");
            driver.FindElementById("button1").Click();

            Assert.AreEqual("3", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod2()
        {
            var driver = setup();

            var test = driver.FindElementById("textBox1");
            test.SendKeys("0");
            driver.FindElementById("button1").Click();

            Assert.AreEqual("1", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod3()
        {
            var driver = setup();

            var test = driver.FindElementById("textBox1");
            test.SendKeys("12");
            driver.FindElementById("button1").Click();

            Assert.AreEqual("1", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod4()
        {
            var driver = setup();

            var test = driver.FindElementById("textBox1");
            test.SendKeys("aaa");
            driver.FindElementById("button1").Click();

            Assert.AreEqual("1", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod5()
        {
            var driver = setup();
            driver.FindElementById("textBox1").SendKeys("3");
            driver.FindElementById("button1").Click();

            var test = driver.FindElementById("textBox2");
            test.SendKeys("1 2");
            driver.FindElementById("button2").Click();

            Assert.AreEqual("1 2\r\n", driver.FindElementById("textBox4").Text);
            Assert.AreEqual("", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod6()
        {
            var driver = setup();
            driver.FindElementById("textBox1").SendKeys("3");
            driver.FindElementById("button1").Click();

            var test = driver.FindElementById("textBox2");
            test.SendKeys("a a");
            driver.FindElementById("button2").Click();

            Assert.AreEqual("", driver.FindElementById("textBox4").Text);
            Assert.AreEqual("a a", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod7()
        {
            var driver = setup();
            driver.FindElementById("textBox1").SendKeys("3");
            driver.FindElementById("button1").Click();

            var test = driver.FindElementById("textBox3");
            test.SendKeys("a a");
            driver.FindElementById("button3").Click();

            Assert.AreEqual("", driver.FindElementById("textBox4").Text);
            Assert.AreEqual("a a", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod8()
        {
            var driver = setup();
            driver.FindElementById("textBox1").SendKeys("3");
            driver.FindElementById("button1").Click();
            driver.FindElementById("textBox2").SendKeys("1 2");
            driver.FindElementById("button2").Click();

            var test = driver.FindElementById("textBox3");
            test.SendKeys("1 2");
            driver.FindElementById("button3").Click();

            Assert.AreEqual("", driver.FindElementById("textBox4").Text);
            Assert.AreEqual("", test.Text);

            driver.Quit();
        }
        //[TestMethod]
        public void TestMethod9()
        {
            var driver = setup();
            driver.FindElementById("textBox1").SendKeys("2");
            driver.FindElementById("button1").Click();
            driver.FindElementById("textBox2").SendKeys("1 2");
            driver.FindElementById("button2").Click();

            driver.FindElementById("button4").Click();

            Assert.AreNotEqual("", driver.FindElementById("textBox5").Text);

            driver.Quit();
        }
    }
}