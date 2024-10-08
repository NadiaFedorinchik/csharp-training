using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
    public class ApplicationManager
    {
        public RegistrationHelper registration { get; set; }
        public FtpHelper ftp { get; set; }
        public LoginHelper auth { get { return loginHelper; } }
        public ProjectHelper project { get { return projectHelper; } }

        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected ProjectHelper projectHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
            registration = new RegistrationHelper(this);
            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectHelper(this);
            //driver = new FirefoxDriver(options);
            baseURL = "http://localhost";
            ftp = new FtpHelper(this);
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
                newInstance.driver.Url = "http://localhost/mantisbt-2.27.0/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }

        public string BaseURL
        {
            get { return baseURL; } }

        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    lock (this)
                    {
                        if (driver == null)
                        {
                            driver = new FirefoxDriver(new FirefoxOptions()
                            {
                                BinaryLocation = "C:\\Program Files\\Mozilla Firefox\\firefox.exe"
                            });
                        }
                    }
                }
                return driver;
            }
        }
    }
}
