using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupHelper.CreateNewGroupIfZeroPresent();

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Remove(0);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}

