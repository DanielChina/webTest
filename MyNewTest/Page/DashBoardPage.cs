using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewTest
{
    class DashBoardPage
    {
        public DashBoardPage()
        {
            PageFactory.InitElements(Container.UI, this);
        }
        [FindsBy(How = How.Id, Using = "cart-button")]
        public IWebElement Cartbutton { get; set; }
        

    }
}
