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

            List<ProjectData> oldProjects = app.project.GetProjectList();

            app.project.Create(project);

            Assert.AreEqual(oldProjects.Count + 1, app.project.GetProjectCount());

            List<ProjectData> newProjects = app.project.GetProjectList();
            
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}