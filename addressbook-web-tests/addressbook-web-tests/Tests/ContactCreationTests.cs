using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Kate", "Winslet");
            
            app.ContactHelper.Create(contact);
            app.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            app.ContactHelper.Create(contact);
            app.Auth.Logout();
        }
    }
}
