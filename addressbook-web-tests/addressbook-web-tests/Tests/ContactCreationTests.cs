using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(20), GenerateRandomString(20))
                {
                    MiddleName = GenerateRandomString(20),
                    NickName = GenerateRandomString(20),
                    Company = GenerateRandomString(20),
                    Title = GenerateRandomString(20),
                    Address = GenerateRandomString(20),
                    HomePhone = GenerateRandomNumericString(12),
                    MobilePhone = GenerateRandomNumericString(12),
                    WorkPhone = GenerateRandomNumericString(12),
                    Fax = GenerateRandomNumericString(12),
                    Email = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20),
                    Homepage = GenerateRandomString(20)
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                contacts.Add(new ContactData(parts[0], parts[2])
                {
                    MiddleName = parts[1],
                    NickName = parts[3],
                    Company = parts[4],
                    Title = parts[5],
                    Address = parts[6],
                    HomePhone = parts[7],
                    MobilePhone = parts[8],
                    WorkPhone = parts[9],
                    Fax = parts[10],
                    Email = parts[11],
                    Email2 = parts[12],
                    Email3 = parts[13],
                    Homepage = parts[14]
                });

            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).
                Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactsDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactsDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.ContactHelper.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.ContactHelper.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
