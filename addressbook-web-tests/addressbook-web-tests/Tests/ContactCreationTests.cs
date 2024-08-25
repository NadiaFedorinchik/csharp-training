using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Kate", "Winslet");

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Create(contact);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Create(contact);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();

            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }
    }
}
