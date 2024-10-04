using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;


namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
           List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "test",
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Console.WriteLine(oldGroups);
            Console.WriteLine(newGroups);

            ClassicAssert.AreEqual(oldGroups, newGroups);
        }
    }
}
