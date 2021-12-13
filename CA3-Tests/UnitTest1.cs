using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Collections.ObjectModel;

namespace CA3_Tests
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void HomePage()
        {
            string expectedTitle = "Top 100 Ranked Cryptos";
            driver.Navigate().GoToUrl("http://localhost:34564/");
            IWebElement element = driver.FindElement(By.Id("Title"));
            Assert.AreEqual(expectedTitle, element);
        }
    }
}