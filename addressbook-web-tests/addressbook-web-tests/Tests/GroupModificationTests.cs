using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("e");
            newData.Header = "f";
            newData.Footer = "g";

            app.GroupHelper.Modify(1, newData);
            app.Auth.Logout();
        }
    }
}

