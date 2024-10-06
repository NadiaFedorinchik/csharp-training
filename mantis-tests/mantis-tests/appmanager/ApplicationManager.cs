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

        private IWebDriver driver;
        private string baseURL;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public ApplicationManager() 
        {

            FirefoxOptions options = new FirefoxOptions();
            options.BinaryLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
            registration = new RegistrationHelper(this);
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost";
            ftp = new FtpHelper(this);

            Console.WriteLine("WebDriver создан успешно");
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

        public IWebDriver Driver 
        { get { return driver; } }

        public string BaseURL
        {
            get { return baseURL; } }
    }
}
