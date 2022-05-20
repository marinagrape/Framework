using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject
{
    public class Tests : Base
    {
        [Test]
        public void SuccessfulLogin()
        {

            LogInPage logInPage = new LogInPage(_driver, _wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(_driver, _wait);
            emailPage.WriteEmail("automation.pp@amdaris.com");
            emailPage.PressNextBtn();

            PasswordPage passwordPage = new PasswordPage(_driver, _wait);
            passwordPage.WritePasswd("10704-observe-MODERN-products-STRAIGHT-69112");
            passwordPage.PressNextBtn();

            SignedInPage signedInPage = new SignedInPage(_driver, _wait);
            signedInPage.ClickYesButton();

            Dashboard dashboard = new Dashboard(_driver, _wait);
            dashboard.HelloText("Hi Automation");
        }

        [Test]
        public void LoginWithInvalidEmail()
        {
            LogInPage logInPage = new LogInPage(_driver, _wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(_driver, _wait);
            emailPage.WriteEmail("--------------");
            emailPage.PressNextBtn();
            emailPage.CheckErrorMessage("Введите допустимый адрес электронной почты, номер телефона или логин Skype.");
        }

        [Test]
        public void LoginWithInvalidPassword()
        {
            LogInPage logInPage = new LogInPage(_driver, _wait);
            logInPage.ClickLogInButton();

            EmailPage emailPage = new EmailPage(_driver, _wait);
            emailPage.WriteEmail("automation.pp@amdaris.com");
            emailPage.PressNextBtn();

            PasswordPage passwordPage = new PasswordPage(_driver, _wait);
            passwordPage.WritePasswd("VeryWrongPassword56789");
            passwordPage.PressNextBtn();

            passwordPage.CheckErrorMessage("Неправильная учетная запись или пароль. Если вы не помните свой пароль, сбросьте его.");
        }

        [Test]
        public void FilterNotificationByEntityType()
        {
            SuccessfulLogin();

            Dashboard dashboard = new Dashboard(_driver, _wait);
            dashboard.ClickNotificationBtn();
            dashboard.ClickFilterIcon();
            dashboard.ClickEntityType();
            dashboard.FindEntityType("Employee");
            dashboard.ChooseEmployee();
        }

        [Test]
        public void FindEmployeeByName()
        {
            SuccessfulLogin();

            EmployeePage employeePage = new EmployeePage(_driver, _wait);
            employeePage.OpenEmployeePage();
            employeePage.InputEmployeeName("Alessandro");
            employeePage.FindEmployeeByName("Alessandro");
            employeePage.CheckNumberOfResults();

        }
        [Test]
        public void SearchInexistingEmployee()
        {
            SuccessfulLogin();

            EmployeePage employeePage = new EmployeePage(_driver, _wait);
            employeePage.OpenEmployeePage();
            employeePage.InputEmployeeName("bigboss");
            employeePage.FindInexistingEmployee("No Such Employees");

        }

    }
}