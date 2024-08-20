using OpenQA.Selenium;
using System;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToAddNewPage();

            FillContactForm(contact);
            SubmitContactCreation();

            manager.Navigator.ReturnToHomepage();

            return this;
        }

        public ContactHelper Modify(int rowNumber, ContactData newData)
        {
            InitContactModification(rowNumber);
            FillContactForm(newData);
            SubmitContactModification();

            manager.Navigator.ReturnToHomepage();

            return this;
        }

        public ContactHelper Remove(int rowNumber)
        {
            SelectContact(rowNumber);
            RemoveContact();
            
            return this;
        }

        public ContactHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[@name='submit']")).Click();

            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);

            return this;
        }

        public ContactHelper SelectContact(int rowNumber)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + rowNumber + "]/td[1]/input")).Click();

            return this;
        }

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();

            return this;
        }

        private void InitContactModification(int rowNumber)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + rowNumber + "]/td[8]/a/img")).Click();
        }

        private void SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[@name='update']")).Click();
        }
    }
}
