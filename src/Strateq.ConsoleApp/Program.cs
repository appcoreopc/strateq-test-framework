using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Interactions;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {

            var myDefaultTimeOut = TimeSpan.FromSeconds(10);

            ChromeDriver driver = Login();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Purchase Order")));

            driver.FindElement(By.LinkText("Purchase Order")).Click();

            //var alert = driver.SwitchTo().Alert();
            //alert.Accept();

            driver.FindElement(By.Id("purchaseordersomgr_vendor")).SendKeys("8P0001");

            Thread.Sleep(3000);

            driver.FindElement(By.Id("purchaseordersomgr_vendor")).SendKeys(Keys.Tab);

            Thread.Sleep(2000);

            driver.FindElementById("purchaseordersomgr_remarks2").SendKeys("testtesttest");

            var el = driver.FindElementById("purchaseordersomgr_very_urgent");

            Scroll_Page(el);

            Actions action = new Actions(driver);
            action.MoveToElement(el).Click().Perform();

            Thread.Sleep(2000);

            var el2 = driver.FindElement(By.Id("purchaseorderssomgr_addrow_btn"));

            Scroll_Page(el2);

            Thread.Sleep(2000);

            action = new Actions(driver);
            action.MoveToElement(el2).Click().Perform();

            Thread.Sleep(2000);

            var itemRow1 = driver.FindElement(By.CssSelector("#row0purchaseorders_jqxgrid > div:nth-child(1)"));

            // wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input.jqx-combobox-input jqx-widget-content jqx-rc-all[type='input")));

            ((IJavaScriptExecutor) driver).ExecuteScript("window.scrollBy(0,300)");

            action = new Actions(driver);
            action.MoveToElement(itemRow1).Click().Perform();



        }

        public static void Scroll_Page(IWebElement webelement)
        {
            webelement.SendKeys(Keys.Down);
            Thread.Sleep(500);
        }

        public static void Scroll_Page2(IJavaScriptExecutor driver, IWebElement webelement)
        {
            driver.ExecuteScript("arguments[0].scrollIntoView(true);", webelement);
            Thread.Sleep(500);
        }

        private static ChromeDriver Login()
        {
            var driver = new ChromeDriver();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Navigate().GoToUrl("http://dev03.37degrees.us/STQHIS/OSC");

            driver.FindElementById("user_login_name").SendKeys("dan3");

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.FindElementById("user_password").SendKeys("Password!23");

            Thread.Sleep(5000);

            SelectValue(driver, "location_role_id", "13");

            driver.FindElement(By.Id("submitForm")).Click();

            //wait2.Until(ExpectedConditions.UrlToBe("http://dev03.37degrees.us/STQHIS/OSC/PurchaseOrdersSOMgr/getPurchaseOrderProcessPRForm"));

            //WebDriverWait wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Thread.Sleep(5000);

            return driver;
        }


        static void SelectValue(ChromiumDriver driver, string targetId, string targetValue)
        {

            var education = driver.FindElementById(targetId);
            var selectElement = new SelectElement(education);

            //select by value
            selectElement.SelectByValue(targetValue);

        }
    }
}
