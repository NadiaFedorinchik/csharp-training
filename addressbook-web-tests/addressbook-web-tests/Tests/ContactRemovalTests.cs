using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.CreateNewContactIfZeroPresent();

            app.ContactHelper.Remove(2);

            Assert.AreEqual(oldContacts.Count - 1, app.ContactHelper.GetContactCount());

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}

