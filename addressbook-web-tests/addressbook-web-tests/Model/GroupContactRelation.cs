using LinqToDB;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation : AddressBookDB
    {
        [Column(Name = "group_id")]
        public string GroupId { get; }

        [Column(Name = "id")]
        public string ContactId { get; }
    }
}