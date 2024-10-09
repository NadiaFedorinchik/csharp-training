using System;
using System.Collections.Generic;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public List<ProjectData> GetProjectList(AccountData account)
        {
            List<ProjectData> allProjects = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            List<Mantis.ProjectData> mantisProjects = new List<Mantis.ProjectData>(projects);
            foreach (Mantis.ProjectData mantisProject in mantisProjects)
            {
                ProjectData project = new ProjectData(mantisProject.name);
                project.Id = int.Parse(mantisProject.id);
                project.Name = mantisProject.name;

                allProjects.Add(project);
            }

            return allProjects;
        }

        public void CreateNewProjectIfZeroPresent(AccountData account)
        {
            if (!IsAtLeastOneProjectPresent(account))
            {
                Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
                Mantis.ProjectData project = new Mantis.ProjectData();
                project.name = TestBase.GenerateRandomString(10);
                client.mc_project_add(account.Name, account.Password, project);
            }
        }

        public bool IsAtLeastOneProjectPresent(AccountData account)
        {
            if (GetProjectList(account).Count > 1)
            {
                return true;
            }
            return false;
        }
    }
}
