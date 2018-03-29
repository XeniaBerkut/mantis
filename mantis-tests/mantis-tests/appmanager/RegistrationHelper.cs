using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link")).Click();
            //manager.Driver.FindElement(By.LinkText("зарегистрировать новую учетную запись")).Click();
        }

        public string GetText(string locator)
        {
            return driver.FindElements(By.CssSelector(locator))[2].Text;
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            Type(By.Id("username"), account.Name);
            Type(By.Id("email-field"), account.Email);


        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.12.0/login_page.php";
        }
    }
}
