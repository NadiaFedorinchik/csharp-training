
using OpenQA.Selenium;
using System;

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
            SubmitRegistratio();

        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.27.0/login_page.php";
        }
        public void OpenRegistrationForm()
        {
            manager.Driver.FindElement(By.CssSelector(".back-to-login-link.pull-left")).Click();
        }

        public void FillRegistrationForm(AccountData account)
        {
            manager.Driver.FindElement(By.Name("username")).SendKeys(account.Name);
            manager.Driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void SubmitRegistratio()
        {
            manager.Driver.FindElement(By.CssSelector("input.btn-success")).Click();
        }
    }
}
