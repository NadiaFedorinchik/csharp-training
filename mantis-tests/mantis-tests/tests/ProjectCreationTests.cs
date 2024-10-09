using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectData project = new ProjectData(GenerateRandomString(10));

            //List<ProjectData> oldProjects = app.project.GetProjectList();

            AccountData account = new AccountData
            {
                Name = "administrator",
                Password = "P@ssw0rd"
            };

            List<ProjectData> oldProjects = app.API.GetProjectList(account);

            app.project.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.API.GetProjectList(account).Count);

            List<ProjectData> newProjects = app.API.GetProjectList(account);

            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}