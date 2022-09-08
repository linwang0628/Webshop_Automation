using System.Configuration;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Webshop_Automation.TestSetup
{
    public class BaseTest
    {
        //Setup global variables
        private string homepageUrl = "http://demowebshop.tricentis.com/";


        //Setup chrome driver
        protected IWebDriver driver;

        //webpage elements


        [SetUp]
        public void startDriver()
        {
            //open homepage and maxmise
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        // wait for page element
        public void waitForDelay(int mseconds)
        {
            Thread.Sleep(mseconds);
        }

        //open home page
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(homepageUrl);
        }

        //navigation using categories
        public void navigateToCategory (string category, string subCategory = null)
        {
            driver.FindElement(By.XPath($"//div[contains(@class, 'listbox')]//a[contains(text(),'{category}')]")).Click();
            if (subCategory != null)
            {
                driver.FindElement(By.XPath($"//div[contains(@class, 'listbox')]//a[contains(text(),'{subCategory}')]")).Click();
            }
        }

        //verify title text based on title type and name
        public bool findTitleText(string titleType, string titleName)
        {
            if (driver.FindElement(By.XPath($"//{titleType}[contains(text(),'{titleName}')]")).Displayed==true)
                return true;
            else
                return false; 
        }

        //click checkbox in the webpage by web element id
        public void ClickCheckboxbyID (string id)
        {
            driver.FindElement(By.Id($"{id}")).Click();
        }

        //enter text in the webpage by web element id
        public void EnterTextbyID(string id, string text)
        {
            driver.FindElement(By.Id($"{id}")).SendKeys(text);
        }

        //Click webelement by Xpath
        public void ClickElementbyXpath(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }





        [TearDown]
        //shutdown all chromedrivers after test finished
        public void closeBrowser()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
