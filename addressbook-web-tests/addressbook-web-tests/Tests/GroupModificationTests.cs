using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("h");
            newData.Header = "i";
            newData.Footer = null;

            app.GroupHelper.Modify(1, newData);
            app.Auth.Logout();
        }
    }
}

