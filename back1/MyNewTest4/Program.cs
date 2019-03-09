using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyNewTest
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("https://www.trademe.co.nz/Members/Login.aspx");
        }
        [Test]
        public void execute()
        {
            IWebElement element = driver.FindElement(By.Name("page_email"));
            element.SendKeys("xiazhai2017@gmail.com");
            element = driver.FindElement(By.Name("page_password"));
            element.SendKeys("zyk818311");
            element = driver.FindElement(By.Id("LoginPageButton"));
            element.Click();
         //   Console.WriteLine("execute now");
        }
        [Test]
        public void nextTest()
        {

        }
        [TearDown]
        public void Cleanup()
        {
            driver.Close();
         //   Console.WriteLine("Close");
        }
    }
}
