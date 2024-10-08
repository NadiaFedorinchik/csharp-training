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
            app.project.CreateNewProjectIfZeroPresent();

            List<ProjectData> oldProjects = app.project.GetProjectList();
            ProjectData projectToDelete = oldProjects[1];
            app.project.Delete(projectToDelete);

            Assert.AreEqual(oldProjects.Count - 1, app.project.GetProjectCount());

            List<ProjectData> newProjects = app.project.GetProjectList();
            
            oldProjects.RemoveAt(1);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}