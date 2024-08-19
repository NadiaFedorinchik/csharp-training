using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.GroupHelper.Remove(1);
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}

