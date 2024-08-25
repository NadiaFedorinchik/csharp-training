
using System;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string firstName;
        private string lastName;
        private string fullName;

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public ContactData(string fullName)
        {
            this.fullName = fullName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return fullName == other.fullName;
        }

        public int GetHashcode()
        {
            return fullName.GetHashCode();
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
    }
}
