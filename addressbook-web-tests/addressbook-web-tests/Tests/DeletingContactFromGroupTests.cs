using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class DeletingContactFromGroupTests : AuthTestBase
    {

        [Test]
        public void DeletingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            
            if (oldList == null || oldList.Count == 0)
            {
                ContactData contact = ContactData.GetAll().Except(oldList).First();
                app.ContactHelper.AddContactToGroup(contact, group);
            }

            oldList = group.GetContacts();
            ContactData contactToDelete = oldList[0];

            app.ContactHelper.DeleteContactFromGroup(contactToDelete, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactToDelete);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);

        }
    }
}

