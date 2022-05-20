using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class EmailPage : Base
    {


        public EmailPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _driver = webDriver;
            _wait = wait;
        }

        private IWebElement emailField => _driver.FindElement(By.XPath("//input[@type = 'email']"));
        private IWebElement nextBtn => _driver.FindElement(By.XPath("//input[@type = 'submit']"));
        private By errorMessage => By.Id("usernameError");

        public void WriteEmail(string email)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(emailField)).SendKeys(email);
        }
        public void PressNextBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextBtn)).Click();
        }

        public void CheckErrorMessage(string exceptedResult)
        {
            string actualErrorMessage = _wait.Until(ExpectedConditions.ElementIsVisible(errorMessage)).Text;

            Assert.AreEqual(exceptedResult, actualErrorMessage);
        }

    }
}
