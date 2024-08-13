using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GoToAddNewPage();
            ContactData contact = new ContactData("Kate", "Winslet");
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomepage();
            Logout();
        }
    }
}
