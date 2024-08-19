using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Leo", "DiCaprio");

            app.ContactHelper.Modify(2, newData);
            app.Auth.Logout();
        }
    }
}

