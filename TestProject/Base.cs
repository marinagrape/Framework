using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class Base
    {
        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArguments("--disable-default-apps");
            options.AddArguments("--incognito");

            _driver = new ChromeDriver(options);
            _driver.Navigate().GoToUrl("https://projectplanappweb-stage.azurewebsites.net/login");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
