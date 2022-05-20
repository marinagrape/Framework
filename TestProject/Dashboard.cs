using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class Dashboard : Base
    {

        public Dashboard(IWebDriver webDriver, WebDriverWait wait)
        {
            _driver = webDriver;
            _wait = wait;
        }

        private By hello => By.CssSelector("div .page-overview > div:nth-child(2)>div>div>h1");
        private IWebElement notifcationBtn => _driver.FindElement(By.CssSelector("button.notification-icon > span"));
        private IWebElement filterIcon => _driver.FindElement(By.CssSelector("div.actions > button:first-child"));
        private IWebElement entityTypeItem => _driver.FindElement(By.XPath("//mat-select[@formcontrolname = 'typeId' or @placeholder = 'Entity Type']"));
        private IWebElement entityTypeElement => _driver.FindElement(By.CssSelector("mat-option:nth-child(3)>span.mat-option-text"));
        private IWebElement employeeType => _driver.FindElement(By.CssSelector("mat-option:nth-child(3)>span.mat-option-text"));

        public void HelloText(string exceptedResult)
        {
            string actualStartText = _wait.Until(ExpectedConditions.ElementIsVisible(hello)).Text;

            Assert.AreEqual(exceptedResult, actualStartText);
        }

        public void ClickNotificationBtn()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(notifcationBtn)).Click();
        }

        public void ClickFilterIcon()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(filterIcon)).Click();
        }

        public void ClickEntityType()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(entityTypeItem)).Click();
        }

        public void FindEntityType(string exceptedResult)
        {
            string actualFilter = _wait.Until(ExpectedConditions.ElementToBeClickable(entityTypeElement)).Text;

            Assert.AreEqual(exceptedResult, actualFilter);
        }
        public void ChooseEmployee()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(employeeType)).Click();
        }

    }
}
