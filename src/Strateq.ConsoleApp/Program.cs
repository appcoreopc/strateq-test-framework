using System;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Chromium;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {

            var myDefaultTimeOut = TimeSpan.FromSeconds(10);

            ChromeDriver driver = Login();

            //_ = driver.Manage().Timeouts().ImplicitWait;

            // WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Purchase Order")));// instead of id u can use cssSelector or xpath of ur element.


            driver.FindElement(By.LinkText("Purchase Order")).Click();

            driver.FindElement(By.Id("purchaseordersomgr_vendor")).SendKeys("8P0004");

            driver.FindElement(By.Id("purchaseordersomgr_vendor")).SendKeys(Keys.Enter);

            driver.FindElement(By.Id("purchaseorderssomgr_addrow_btn")).Click();


            //IWebElement firstResult = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h3>div")));
            //Console.WriteLine(firstResult.GetAttribute("textContent"));

            driver.Close();
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
