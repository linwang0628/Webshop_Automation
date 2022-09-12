using System.Configuration;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;

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

        //navigation using navigation box
        public void NavigateToCategory(string category, string? subCategory = null)
        {
            driver.FindElement(By.XPath($"//div[contains(@class, 'listbox')]//a[contains(text(),'{category}')]")).Click();
            if (subCategory != null)
            {
                driver.FindElement(By.XPath($"//div[contains(@class, 'listbox')]//a[contains(text(),'{subCategory}')]")).Click();
            }
        }

        //navigation using navigation bar
        public void NavigateToCategoryUsingNavBar(string category, string? subCategory = null)
        {
            Actions action = new Actions(driver);
            IWebElement mainCategory = driver.FindElement(By.XPath($"//div[contains(@class, 'header-menu')]//a[contains(text(),'{category}')]"));
            IWebElement subCategoryElement = driver.FindElement(By.XPath($"//div[contains(@class, 'header-menu')]//a[contains(text(),'{subCategory}')]"));
            if (subCategory != null)
            {
                action.MoveToElement(mainCategory).MoveToElement(subCategoryElement).Click().Perform();
            }
            else
                mainCategory.Click();
        }

        //click item by itemName
        public void ClickItem(string itemName)
        {
            ClickElementbyXpath($"//a[contains(text(),'{itemName}')]");
        }

        //verify title text based on title type and name
        public bool findTitleText(string titleType, string titleName)
        {
            try
            {
                driver.FindElement(By.XPath($"//{titleType}[contains(text(),'{titleName}')]"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //click element in the webpage by web element id
        public void ClickElementbyID(string id)
        {
            driver.FindElement(By.Id($"{id}")).Click();
        }

        //enter text in the webpage by web element id
        public void EnterTextbyID(string id, string text)
        {
            driver.FindElement(By.Id($"{id}")).Clear();
            driver.FindElement(By.Id($"{id}")).SendKeys(text);
        }

        //enter text in the webpage by web element id
        public void EnterTextbyXpath(string Xpath, string text)
        {
            driver.FindElement(By.XPath($"{Xpath}")).Clear();
            driver.FindElement(By.XPath($"{Xpath}")).SendKeys(text);
        }

        //click webelement by Xpath
        public void ClickElementbyXpath(string xpath)
        {
            driver.FindElement(By.XPath(xpath)).Click();
        }


        //check shopping cart count
        public bool VerifyShoppingCartCount(int count)
        {
            driver.Navigate().Refresh();
            if (driver.FindElement(By.XPath("//span[@class='cart-qty']")).ToString() == $"({count})")
                return true;
            else
                return false;
        }


        //check price for the item purchased
        public bool VerifyItemTotalPrice(string itemName, string price)
        {
            if (driver.FindElement(By.XPath($"//tr//a[contains(text(),'{itemName}')]/../..//span[@class='product-subtotal']")).ToString() == price.ToString())
                return true;
            else
                return false;
        }


        //select from from dropdown menu
        public void SelectItemFromDropdown(string dropdownId,string itemName)
        {
            SelectElement drpDown = new SelectElement(driver.FindElement(By.Id(dropdownId)));
            drpDown.SelectByText(itemName);
        }

        public void DismissAlertWarning()
        {
            driver.SwitchTo().Alert().Accept();
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
