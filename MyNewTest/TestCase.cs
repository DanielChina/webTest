using MyNewTest.Page;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyNewTest
{
    class TestCase
    {
        private static string AccountPath= @"C:\Users\THink\source\repos\MyNewTest\MyNewTest\account.xlsx";
        private static string BoundaryCasePath = @"C:\Users\THink\source\repos\MyNewTest\MyNewTest\case\cart.xlsx";
        //check cart and set the number to purchase after login
        public static void LoginAndCheckCart(IWebDriver container)
        {
            DashBoardAfterLogin(container);
            CartPage cart = new CartPage();
            Thread.Sleep(2000);
            //clear the original data and set a new one
            SeleniumUtil.SetText(cart.Quantity, "");
            Thread.Sleep(1000);
            SeleniumUtil.SetText(cart.Quantity, "3");
            Thread.Sleep(2000);
            SeleniumUtil.SelectDropDown(cart.Shipping.ElementAtOrDefault<IWebElement>(1),2);
            Thread.Sleep(2000);
            SeleniumUtil.Click(cart.Proceed);
        }
        public static void DashBoardAfterLogin(IWebDriver container)
        {
            Login(container, false);
            DashBoardPage dashBoardPage = new DashBoardPage();
            Thread.Sleep(2000);
            SeleniumUtil.Click(dashBoardPage.Cartbutton);
        }
        public static void Login(IWebDriver container, Boolean dataFromExl)
        {
            LoginPage obj = new LoginPage();
            if (dataFromExl)
            {     
                ExcelDataHelper.PopulateInCollection(AccountPath);
                SeleniumUtil.OpenUrl(container, ExcelDataHelper.ReadData(1, "url"));
                SeleniumUtil.SetText(obj.Username, ExcelDataHelper.ReadData(1, "username"));
                SeleniumUtil.SetText(obj.Password, ExcelDataHelper.ReadData(1, "password"));
                SeleniumUtil.Click(obj.LoginButton);
            }
            else
            {
                SeleniumUtil.OpenUrl(container, "https://www.trademe.co.nz/Members/Login.aspx");
                SeleniumUtil.SetText(obj.Username, "xiazhai2017@gmail.com");
                SeleniumUtil.SetText(obj.Password, "zyk818311");
                SeleniumUtil.Click(obj.LoginButton);
            }
        }
        public static void BoundaryTestCase(IWebDriver container)
        {
            int val=0;
            ExcelDataHelper.PopulateInCollection(BoundaryCasePath);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    DashBoardAfterLogin(container);
                    CartPage cart = new CartPage();
                    Thread.Sleep(1000);
                    //clear the original data and set a new one
                    SeleniumUtil.SetText(cart.Quantity, "");
                    Thread.Sleep(1000);
                    SeleniumUtil.SetText(cart.Quantity, ExcelDataHelper.ReadData((i + 1), "quantity"));
                    Thread.Sleep(1000);
                    string index = ExcelDataHelper.ReadData((i + 1), "shippingIndex");
                    Int32.TryParse(index, out val);
                    SeleniumUtil.SelectDropDown(cart.Shipping.ElementAtOrDefault<IWebElement>(1), val);
                    Thread.Sleep(1000);
                    SeleniumUtil.Click(cart.Proceed);
                }
                catch (Exception e)
                {
                    return;
                }
                
            }
        }
        public static void TestAndSaveResult(IWebDriver container)
        {
            int val = 0;
            ExcelDataHelper.PopulateInCollection(BoundaryCasePath);
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    DashBoardAfterLogin(container);
                    CartPage cart = new CartPage();
                    Thread.Sleep(1000);
                    //clear the original data and set a new one
                    SeleniumUtil.SetText(cart.Quantity, "");
                    Thread.Sleep(3000);
                    SeleniumUtil.SetText(cart.Quantity, ExcelDataHelper.ReadData((i + 1), "quantity"));
                    Thread.Sleep(3000);
                    //string index = ExcelDataHelper.ReadData((i + 1), "shippingIndex");
                    //Int32.TryParse(index, out val);
                    //SeleniumMethods.SelectDropDown(cart.Shipping.ElementAtOrDefault<IWebElement>(1), val);
                    //Thread.Sleep(1000);
                    string total= SeleniumUtil.GetText(cart.FinalTotal);
                    Thread.Sleep(2000);
                    if (!total.Equals(null))
                        ExcelDataHelper.WriteData(BoundaryCasePath, (2+i), 3, total);
                    SeleniumUtil.Click(cart.Proceed);
                    ConfirmationPage confirmation = new ConfirmationPage();
                    Thread.Sleep(1000);
                    total = SeleniumUtil.GetText(confirmation.FinalPaymentTotal);
                    Thread.Sleep(1000);
                    if (!total.Equals(null))
                        ExcelDataHelper.WriteData(BoundaryCasePath, (2 + i), 4, total);

                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }

    }
}
