using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class AddingContactToGroupTests : AuthTestBase
    {

        [Test]
        public void AddingContactToGroup()
        {

            List<ContactData> existingContacts = ContactData.GetAll();
            if (existingContacts == null || existingContacts.Count == 0)
            {
                CreateContactForTest();
            }

            List<GroupData> existingGroups = GroupData.GetAll();
            if (existingGroups == null || existingGroups.Count == 0)
            {
                GroupData newGroup = new GroupData("a");
                newGroup.Header = "b";
                newGroup.Footer = "c";

                app.GroupHelper.Create(newGroup);
            }

            existingGroups = GroupData.GetAll();
            GroupData group = existingGroups[0];
            List<ContactData> oldContactsList = group.GetContacts();
            existingContacts = ContactData.GetAll();
            List<ContactData> contactsOutOfGroup = existingContacts.Except(oldContactsList).ToList();
            if (contactsOutOfGroup == null || contactsOutOfGroup.Count == 0)
            {
                CreateContactForTest();
            }

            ContactData contact = ContactData.GetAll().Except(oldContactsList).First();

            app.ContactHelper.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldContactsList.Add(contact);
            oldContactsList.Sort();
            newList.Sort();

            Assert.AreEqual(oldContactsList, newList);
        }

        private void CreateContactForTest()
        {
            app.ContactHelper.Create(new ContactData("James", "Cameron"));
        }
    }
}

