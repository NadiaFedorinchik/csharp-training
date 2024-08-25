using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Leo", "DiCaprio");

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Modify(2, newData);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();

            Assert.AreNotEqual(oldContacts, newContacts);
        }
    }
}

