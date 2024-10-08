using NUnit.Framework;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {

        [SetUp]
        public void SetupLogin()
        {
            app.auth.Login(new AccountData()
            {
                Name = "administrator",
                Password = "P@ssw0rd"
            });
        }
    }
}
