using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class ProjectHelper : LoginHelper
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { }

        internal void Create(ProjectData project)
        {
            OpenManagePage();
            SelectProjectTab();
            manager.Driver.FindElements(By.CssSelector(".btn.btn-primary.btn-white.btn-round"))[0].Click();
            FillProjectForm(project);
            SubmitProjectCreation();
            project.Id = GetProjectIdByName(project.Name);
        }

        private void SubmitProjectCreation()
        {
            manager.Driver.FindElement(By.CssSelector(".btn.btn-primary.btn-white.btn-round")).Click();
            projectCache = null;
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Name("name"), project.Name);
        }

        private void SelectProjectTab()
        {
            manager.Driver.FindElement(By.XPath("//*[@id='main-container']/div[2]/div[2]/div/ul/li[3]/a")).Click();
        }

        private void OpenManagePage()
        {
            manager.Driver.FindElement(By.CssSelector("#sidebar > ul > li:nth-child(7) > a")).Click();
        }

        internal int GetProjectCount()
        {
            return manager.Driver.FindElements(By.CssSelector("a.project-link")).Count;
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList()
        {
            if (projectCache == null)
            {
                projectCache = new List<ProjectData>();

                ICollection<IWebElement> elements = manager.Driver.FindElements(By.CssSelector("a.project-link"));
                foreach (IWebElement element in elements)
                {
                    string href = element.GetAttribute("href");
                    int projectId = int.Parse(href.Substring(href.LastIndexOf('=') + 1));
                    string projectName = element.GetAttribute("innerText");
                    projectCache.Add(new ProjectData(element.GetAttribute("innerText"))
                    {
                        Id = projectId
                    });
                }
            }

            return new List<ProjectData>(projectCache);
        }

        public int GetProjectIdByName(string projectName)
        {
            var projectLinks = manager.Driver.FindElements(By.CssSelector("a.project-link"));
            foreach (var link in projectLinks)
            {

                string projectNameFromHtml = link.GetAttribute("innerText");
                if (projectNameFromHtml.Equals(projectName))
                {
                    string href = link.GetAttribute("href");
                    int projectId = ExtractProjectIdFromHref(href);
                    return projectId;
                }
            }

            throw new Exception($"Project with name '{projectName}' not found");
        }

        private int ExtractProjectIdFromHref(string href)
        {
            var regex = new Regex(@"project_id=(\d+)");
            var match = regex.Match(href);

            if (match.Success)
            {
                return int.Parse(match.Groups[1].Value);
            }
            else
            {
                throw new Exception("Couldn't get ID from href");
            }
        }
    }
}
