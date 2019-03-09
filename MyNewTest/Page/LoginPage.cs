using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewTest
{
    class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Container.UI, this);
        }
        [FindsBy(How = How.Name, Using = "page_email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Name, Using = "page_password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "LoginPageButton")]
        public IWebElement LoginButton { get; set; }
    }
}
