using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;
namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        AccountData account = new AccountData()
        {
            Name = "administrator",
            Password = "root"
        };

        public void CreateNewIssue(ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.name = project.Name;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public void CreateProject(ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData newProject = new Mantis.ProjectData();
            newProject.name = project.Name;
            client.mc_project_add(account.Name, account.Password, newProject);
        }

        public List<ProjectData> GetProjects()
        {
            List < ProjectData > list = new List<ProjectData>();
            
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            foreach (Mantis.ProjectData project in projects)
            {
                list.Add(new ProjectData()
                {
                    Name = project.name,
                    Description = project.description
                });
            }
            return list;
        }        
    }
}
