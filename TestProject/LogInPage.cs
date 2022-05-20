using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class LogInPage : Base
    {


        public LogInPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _driver = webDriver;
            _wait = wait;
        }
        private IWebElement _logInBtn => _driver.FindElement(By.CssSelector(".button > span"));

        public void ClickLogInButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_logInBtn)).Click();
        }
    }
}
