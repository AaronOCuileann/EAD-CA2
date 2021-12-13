using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace CA3_Tests
{
    public class Tests
    {
        WebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void HomePage()
        {
            driver.Navigate().GoToUrl("http://crypto-currency-api.azurewebsites.net/");
            Thread.Sleep(10000);
            IWebElement HomePageHeader = driver.FindElement(By.Id("cryptoTitle"));
            Assert.IsTrue(HomePageHeader.Text.Contains("Top 100 Ranked Cryptos"));
        }

        [Test]
        public void SearchPage()
        {
            driver.Navigate().GoToUrl("http://crypto-currency-api.azurewebsites.net/");
            Thread.Sleep(10000);
            driver.FindElement(By.Id("search-name")).Click();
            driver.FindElement(By.Id("search-name")).SendKeys("tether");
            Thread.Sleep(2000);
            IWebElement CryptoName = driver.FindElement(By.TagName("td"));
            Thread.Sleep(2000);
            Assert.IsTrue(CryptoName.Text.Contains("4"));
        }

        [Test]
        public void MarketsPage()
        {
            driver.Navigate().GoToUrl("http://crypto-currency-api.azurewebsites.net/crypto/90");
            Thread.Sleep(10000);
            IWebElement HomePageHeader = driver.FindElement(By.Id("MarketTitle"));
            Assert.IsTrue(HomePageHeader.Text.Contains("Crypto Markets"));
        }
    }
}