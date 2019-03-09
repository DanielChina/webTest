using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyNewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trademe.co.nz/Members/Login.aspx");
            //find element
            IWebElement element = driver.FindElement(By.Name("page_email"));
            element.SendKeys("xiazhai2017@gmail.com");
        }
    }
}
