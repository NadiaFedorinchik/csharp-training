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

            app.ContactHelper.CreateNewContactIfZeroPresent();

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Modify(2, newData);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

