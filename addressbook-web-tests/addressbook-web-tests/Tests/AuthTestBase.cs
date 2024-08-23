using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AuthTestBase : TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
