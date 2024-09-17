using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Id { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }

        public string AllPhones
        {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanupEmail(Email) + CleanupEmail(Email2) + CleanupEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    string phones = AllPhones;
                    string info = FirstName + AddSpaceIfNotEmpty(MiddleName) + LastName.PadLeft(LastName.Length + 1) + CleanupDetails(NickName) + CleanupDetails(Title) + CleanupDetails(Company) + CleanupDetails(Address) + AddInfo(HomePhone) + AddInfo(MobilePhone) + AddInfo(WorkPhone) + AddInfo(Fax) + AddSymbols(AllEmails) + AddInfo(Homepage).Trim();
                    if (info == "" || info == " ")
                    {
                        return String.Empty;
                    }
                    else if (info.IndexOf(LastName) + LastName.Length < info.Length)
                    {
                        if (phones != null || phones != "")
                            {
                                info = FirstName + AddSpaceIfNotEmpty(MiddleName) + LastName.PadLeft(LastName.Length + 1) + CleanupDetails(NickName) + CleanupDetails(Title) + CleanupDetails(Company) + CleanupDetails(Address) + "\r\n" + AddInfo(HomePhone) + AddInfo(MobilePhone) + AddInfo(WorkPhone) + AddInfo(Fax) + AddSymbols(AllEmails) + AddInfo(Homepage).Trim(); ;
                            }
                        info = info.Replace(LastName, LastName + "\r\n");
                    }
                    return RemoveTralingSymbols(info);
                }
            }
            set
            {
                allDetails = value;
            }
        }

        private string RemoveTralingSymbols(string inputString)
        {
            {
                if (inputString.EndsWith("\r\n"))
                {
                    return inputString.Substring(0, inputString.Length - 2);
                }
                else
                {
                    return inputString;
                }
            }
        }

        public string Cleanup(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(text, "[ -()]", "") + "\r\n";
            }
        }

        public string CleanupEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            else
            {
                return email.Replace(" ", "") + "\r\n";
            }
        }

        public string CleanupDetails(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(text, "[()]", "") + "\r\n";
            }
        }

        public string AddSymbols(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                return "\r\n" + text.Replace(" ", "") + "\r\n";
            }
        }

        public string AddInfo(string text)
        {
            {
                if (text == null || text == "")
                {
                    return "";
                }
                else if (text == HomePhone)
                {
                    return "H: " + Cleanup(text);
                }
                else if (text == MobilePhone)
                {
                    return "M: " + Cleanup(text);
                }
                else if (text == WorkPhone)
                {
                    return "W: " + Cleanup(text);
                }
                else if (text == Homepage)
                {
                    return "Homepage:\r\n" + CleanupDetails(Homepage);
                }
                return "F: " + Cleanup(text); ;
            }
        }

        public string AddSpaceIfNotEmpty(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                return text.PadLeft(text.Length + 1);
            }
        }
        
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
            AllDetails = allDetails;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return FirstName == other.FirstName
                && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return (FirstName + " " + LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "first name=" + FirstName + " " + "last name=" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int comparison = LastName.CompareTo(other.LastName);
            if (comparison != 0)
            {
                return comparison;
            }

            return FirstName.CompareTo(other.FirstName);
        }
    }
}
