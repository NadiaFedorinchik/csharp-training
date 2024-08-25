using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("h");
            newData.Header = "i";
            newData.Footer = null;

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Modify(0, newData);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            Assert.AreNotEqual(oldGroups, newGroups);
        }
    }
}

