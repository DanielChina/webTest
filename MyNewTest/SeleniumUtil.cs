using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewTest
{
    class SeleniumUtil
    {
        public static void SetText(IWebElement element, string value)
        {
            if (value.Equals(""))
                element.Clear();
            else
                element.SendKeys(value);
        }
        public static void Click(IWebElement element)
        {
          //  element.Submit();
            element.Click();
        }
        public static void SelectDropDown(IWebElement element, int value)
        {
             new SelectElement(element).SelectByIndex(value);
           // element.SendKeys(value);
        }

        public static string GetText(IWebElement element)
        {
            return element.Text.ToString();
        }
        public static string GetTextFromDropDownList(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
        public static void OpenUrl(IWebDriver contain, string  url)
        {
            contain.Navigate().GoToUrl(url);
        }
    }
}
