using addressbook_tests_autoit;
using NUnit.Framework;


namespace addressbook_tests_autoit
{
    public class TestBase
    {
        protected ApplicationManager app;
        
        [SetUp]
        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void stopApplication()
        {
            app.Stop();
        }
    }
}