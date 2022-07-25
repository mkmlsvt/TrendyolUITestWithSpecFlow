using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TrendyolUITestSpecFlow.Constants;

namespace TrendyolUITestSpecFlow.StepDefinitions
{
    [Binding]
    public class TrendyolRemoveFromBasketStepDefinitions
    {

        string str;
        IWebDriver driver = new ChromeDriver();
        [Given(@"A product must be added to cart")]
        public void GivenAProductMustBeAddedToCart()
        {
            driver.Navigate().GoToUrl("https://www.trendyol.com/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName(Constant.SearchBoxClassName)).SendKeys("monster" + Keys.Enter);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Constant.GoToProductPageA)));
            str = driver.FindElement(By.XPath(Constant.GoToProductPageA)).GetAttribute("href");
            driver.Navigate().GoToUrl(str);
            wait.Until(ExpectedConditions.ElementExists(By.ClassName(Constant.AddToBasketButton)));
            //sepete ekleniyor
            driver.FindElement(By.ClassName(Constant.AddToBasketButton)).Click();
            Thread.Sleep(2000);
        }
        [Given(@"the url where we are going for is trendyol sepet")]
        public void GivenTheUrlWhereWeAreGoingForIsTrendyolSepet()
        {
            driver.Navigate().GoToUrl("https://www.trendyol.com/sepet");
        }

        [Given(@"I close the pop up")]
        public void GivenICloseThePopUp()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Constant.PopUpCloseRemoveBasket)));
            driver.FindElement((By.XPath(Constant.PopUpCloseRemoveBasket))).Click();
        }

        [When(@"click to remove basket")]
        public void WhenClickToRemoveBasket()
        {
            driver.FindElement((By.XPath(Constant.RemoveToBasketButton))).Click();
        }

        [Then(@"I verify prodcut is remove to basket")]
        public void ThenIVerifyProdcutIsRemoveToBasket()
        {
            Thread.Sleep((2000));
            bool verifyRemoved = driver.FindElement(By.XPath(Constant.WarningToEmptyBasket)).Displayed;
            Assert.IsTrue(verifyRemoved);
        }
    }
}
