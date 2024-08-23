using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        

        [Test]
        public void LoginWithValidCredentialsTest()
        {
            app.Auth.Logout();

            AccountData adminAccount = new AccountData("admin", "secret");

            app.Auth.Login(adminAccount);

            Assert.IsTrue(app.Auth.IsLoggedIn(adminAccount));
        }

        [Test]
        public void LoginWithInvalidCredentialsTest()
        {
            app.Auth.Logout();

            AccountData adminAccount = new AccountData("admin", "invalid_password");

            app.Auth.Login(adminAccount);

            Assert.IsFalse(app.Auth.IsLoggedIn(adminAccount));
        }
    }
}
