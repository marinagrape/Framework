using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class EmployeePage : Base
    {


        public EmployeePage(IWebDriver webDriver, WebDriverWait wait)
        {
            _driver = webDriver;
            _wait = wait;
        }

        private IWebElement _employeeBtn => _driver.FindElement(By.CssSelector("a#employees-tab"));
        private IWebElement _searchField => _driver.FindElement(By.CssSelector("input.input-search"));
        private IWebElement _searchResult => _driver.FindElement(By.CssSelector("span.name"));
        private IWebElement _searchNotFound => _driver.FindElement(By.XPath(("//div[contains(text(),'No such employees')]")));
        private By _numberOfResults => By.CssSelector("div.num");

        public void OpenEmployeePage()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_employeeBtn)).Click();
        }

        public void InputEmployeeName(string name)
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_searchField)).SendKeys(name);
        }
        public void FindEmployeeByName(string expectedResult)
        {
            string actualSearchResult = _wait.Until(ExpectedConditions.ElementToBeClickable(_searchResult)).Text;

            Assert.That(actualSearchResult, Does.Contain(expectedResult).IgnoreCase);
        }

        public void CheckNumberOfResults()
        {
            string actualSearchResult = _wait.Until(ExpectedConditions.ElementIsVisible(_numberOfResults)).Text;

            Assert.IsNotNull(actualSearchResult);
        }

        public void FindInexistingEmployee(string expectedResult)
        {
            string actualSearchResult = _wait.Until(ExpectedConditions.ElementToBeClickable(_searchNotFound)).Text;

            Assert.That(actualSearchResult, Does.Contain(expectedResult).IgnoreCase);
        }
    }
}
