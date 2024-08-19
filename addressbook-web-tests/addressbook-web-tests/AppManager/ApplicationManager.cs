using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager() 
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this,  baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        public IWebDriver Driver 
        { get { return driver; } }

        public string BaseURL
        {
            get { return baseURL; } }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper Auth
            { get { return loginHelper; } }

        public NavigationHelper Navigator
            { get { return navigator; } }

        public GroupHelper GroupHelper
        { get { return groupHelper; } }

        public ContactHelper ContactHelper
        { get { return contactHelper; } }
    }
}
