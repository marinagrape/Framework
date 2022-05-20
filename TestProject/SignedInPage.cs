using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
namespace TestProject
{
    public class SignedInPage : Base
    {

        public SignedInPage(IWebDriver webDriver, WebDriverWait wait)
        {
            _driver = webDriver;
            _wait = wait;
        }

        private IWebElement _yesBtn => _driver.FindElement(By.XPath("//input[@type = 'submit']"));

        public void ClickYesButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_yesBtn)).Click();
        }

    }
}
