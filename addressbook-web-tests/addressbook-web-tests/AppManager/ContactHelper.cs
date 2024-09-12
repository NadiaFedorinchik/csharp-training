using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;

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

        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.OpenHomePage();

            InitContactModification(index);
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

        public void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();

            IList <IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string email = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                Email = email
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();

            InitContactModification(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email
            };
        }
    }
}