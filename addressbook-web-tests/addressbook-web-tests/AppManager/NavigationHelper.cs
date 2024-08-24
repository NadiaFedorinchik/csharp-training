using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base (manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php" 
                && IsElementPresent(By.LinkText("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void GoToAddNewPage()
        {
            driver.FindElement(By.LinkText("add new")).Click(); ;
        }

        public void ReturnToHomepage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}