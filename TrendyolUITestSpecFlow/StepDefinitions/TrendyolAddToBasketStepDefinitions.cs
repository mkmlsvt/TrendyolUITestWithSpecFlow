using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;
using TrendyolUITestSpecFlow.Constants;
using System.Threading;

namespace TrendyolUITestSpecFlow.StepDefinitions
{
    [Binding]
    public class TrendyolAddToBasketStepDefinitions
    {
               
        string str;
        IWebDriver driver = new ChromeDriver();
        [Given(@"the url where we are going for is trendyol")]
        public void GivenTheUrlWhereWeAreGoingForIsHttpsWww_Trendyol_Com()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trendyol.com/");
        }

        [Given(@"the searching word is monster")]
        public void GivenTheSearchingWordIsMonster()
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName(Constant.SearchBoxClassName)).SendKeys("monster" + Keys.Enter);
            wait.Until(ExpectedConditions.ElementExists(By.XPath(Constant.GoToProductPageA)));
            str = driver.FindElement(By.XPath(Constant.GoToProductPageA)).GetAttribute("href");
        }

        [Given(@"I go to product page")]
        public void GivenIGoToProductPage()
        {
            driver.Navigate().GoToUrl(str);
        }

        [When(@"click to add basket")]
        public void WhenClickToAddBasket()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.ClassName("add-to-basket")));
            //sepete ekleniyor
            driver.FindElement(By.ClassName(Constant.AddToBasketButton)).Click();
        }

        [Then(@"I verify prodcut is addet to basket")]
        public void ThenIVerifyProdcutIsAddetToBasket()
        {
            Thread.Sleep(2000);
            //*[@id="account-navigation-container"]/div/div[2]/a/div[2]
            bool verifyAddToBasket = driver.FindElement(By.XPath(Constant.VerifyAddToBasketBasketCount)).Displayed;
            Assert.IsTrue(verifyAddToBasket); 
        }
    }
}
