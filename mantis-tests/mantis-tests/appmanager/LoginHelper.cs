using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            
            Type(By.Name("username"), account.Name);
            manager.Driver.FindElement(By.CssSelector("input.btn-success")).Click();
            Type(By.Name("password"), account.Password);
            manager.Driver.FindElement(By.CssSelector("input.btn-success")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUserName() == account.Name;
        }

        public string GetLoggedUserName()
        {
            string text = manager.Driver.FindElement(By.CssSelector(".user-info")).Text;
            return text;
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector(".user-info"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                manager.Driver.FindElement(By.CssSelector(".user-info")).Click();
                manager.Driver.FindElement(By.XPath("//*[@id=\"navbar-container\"]/div[2]/ul/li[3]/ul/li[4]/a")).Click();
            }
        }
    }
}
