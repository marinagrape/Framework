using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class PasswordPage : Base
    {
        public PasswordPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _driver = webDriver;
            _wait = wait;
        }

        private By passwdField => By.XPath("//input[@type = 'password']");
        private IWebElement nextBtn => _driver.FindElement(By.XPath("//input[@type = 'submit']"));
        private By errorMessage => By.Id("passwordError");

        public void WritePasswd(string passwd)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(passwdField)).SendKeys(passwd);
        }
        public void PressNextBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(nextBtn)).Click();
        }

        public void CheckErrorMessage(string exceptedResult)
        {
            string actualErrorMessage = _wait.Until(ExpectedConditions.ElementIsVisible(errorMessage)).Text;

            StringAssert.AreEqualIgnoringCase(exceptedResult, actualErrorMessage);
        }
    }
}
