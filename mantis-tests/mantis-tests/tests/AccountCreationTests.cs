using NUnit.Framework;
using System.IO;


namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {

        [TestFixtureSetUp]
        public void SetUpConfig()
        {
            app.ftp.BackupFile(@"/config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.ftp.Upload(@"/config/config_inc.php", localFile);
            }
        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "testUser",
                Password = "password",
                Email = "testuser@localhost.localdomain",
            };

            app.registration.Register(account);
        }

        [TestFixtureTearDown]
        public void RestoreConfig()
        {
            app.ftp.RestoreBackupFile(@"/config/config_inc.php");
        }
    }
}
