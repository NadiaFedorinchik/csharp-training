﻿using System;
using System.Threading;
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
        
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager() 
        {

            FirefoxOptions options = new FirefoxOptions();
            options.BrowserExecutableLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
                        
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this,  baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
            if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver 
        { get { return driver; } }

        public string BaseURL
        {
            get { return baseURL; } }

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
