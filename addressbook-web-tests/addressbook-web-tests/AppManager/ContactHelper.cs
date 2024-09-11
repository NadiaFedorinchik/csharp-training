using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            manager.Navigator.GoToAddNewPage();

            FillContactForm(contact);
            SubmitContactCreation();

            manager.Navigator.ReturnToHomepage();

            return this;
        }

        public ContactHelper Modify(int rowNumber, ContactData newData)
        {
            manager.Navigator.OpenHomePage();

            InitContactModification(rowNumber);
            FillContactForm(newData);
            SubmitContactModification();
            
            manager.Navigator.ReturnToHomepage();
            
            return this;
        }

        public ContactHelper Remove(int rowNumber)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(rowNumber);
            RemoveContact();
            
            return this;
        }

        public ContactHelper CreateNewContactIfZeroPresent()
        {
            manager.Navigator.OpenHomePage();

            if (!IsAtLeastOneContactPresent())
            {
                Create(new ContactData("James", "Cameron"));
            }
            return this;
        }

        public bool IsAtLeastOneContactPresent()
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[1]/input"));
        }

        public ContactHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[@name='submit']")).Click();
            contactCache = null;
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

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int rowNumber)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + rowNumber + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[@name='update']")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.OpenHomePage();

                int contactsAmount = GetContactCount();

                for (int i = 2; i <= contactsAmount + 1; i++)
                {
                    IWebElement lastName = driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + i + "]/td[2]"));

                    IWebElement firstName = driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + i + "]/td[3]"));

                    contactCache.Add(new ContactData(firstName.Text, lastName.Text)
                    {
                        Id = driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + i + "]/td[1]")).FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }

            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr")).Count - 1;
        }
    }
}