﻿using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.ContactHelper.GetContactInformationFromTable(0);
            ContactData fromEditForm = app.ContactHelper.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromEditForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
        }

        [Test]
        public void ContactDetailsTest()
        {
            ContactData fromDetailsPage = app.ContactHelper.GetContactInformationFromDetailsPage(2);
            ContactData fromEditForm = app.ContactHelper.GetContactInformationFromEditForm(2);

            string details = fromDetailsPage.AllDetails;
            string edit = fromEditForm.AllDetails;



            Assert.AreEqual(fromDetailsPage.AllDetails, fromEditForm.AllDetails);
        }
    }
}
