using System;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers;

namespace dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
             var driver = new ChromeDriver();
             WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
             driver.Navigate().GoToUrl("https://www.google.com/ncr");
             driver.FindElement(By.Name("q")).SendKeys("cheese" + Keys.Enter);
             //IWebElement firstResult = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h3>div")));
             //Console.WriteLine(firstResult.GetAttribute("textContent"));
        }
    }
}
