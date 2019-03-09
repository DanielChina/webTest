using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewTest
{
    class CartPage
    {
        public CartPage()
        {
            PageFactory.InitElements(Container.UI, this);
        }
        //add button
        [FindsBy(How = How.Name, Using = "buyNowQuantity")]
        public IWebElement Quantity { get; set; }

        //check cart button
        [FindsBy(How = How.Id, Using = "Checkout")]
        public IWebElement Proceed { get; set; }
       
        [FindsBy(How = How.ClassName, Using = "drop-select")]
        public IList<IWebElement> Shipping { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='shopping-cart']/div[4]/div/div[2]/dl/dd/span[2]/span")]
        public IWebElement FinalTotal { get; set; }
        

    }
}
