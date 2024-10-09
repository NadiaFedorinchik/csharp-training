using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeletionTests : AuthTestBase
    {
        [Test]
        public void ProjectDeletionTest()
        {
            //app.project.CreateNewProjectIfZeroPresent();
            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "P@ssw0rd"
            };

            app.API.CreateNewProjectIfZeroPresent(account);

            List<ProjectData> oldProjects = app.API.GetProjectList(account);
            ProjectData projectToDelete = oldProjects[0];
            app.project.Delete(projectToDelete);

            Assert.AreEqual(oldProjects.Count - 1, app.API.GetProjectList(account).Count);

            List<ProjectData> newProjects = app.API.GetProjectList(account);
            
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}