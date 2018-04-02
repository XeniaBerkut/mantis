using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {

        public ProjectHelper(ApplicationManager manager)
    : base(manager)
        {
        }

        public void Create(ProjectData project)
        {
            manager.Navigator.GoToProjPage();
            CreateNewProject();
            FillProjectForm(project);
            SubmitCreate();
        }

        public bool Exists(string name)
        {
            manager.Navigator.GoToProjPage();
            if (IsElementPresent(By.LinkText(name)))
            { return true; }
            else
            { return false; }
        }

        private List<ProjectData> projectCache = null;

        public List<ProjectData> GetProjectList()
        {
            //if (projectCache == null)
            //{
                projectCache = new List<ProjectData>();
                manager.Navigator.GoToProjPage();
                IWebElement table = driver.FindElements(By.XPath("//tbody"))[0];
                //table.Click();
                //IWebElement table2 = driver.FindElements(By.XPath("//tbody"))[2];
                //table2.Click();
                ICollection<IWebElement> elements = table.FindElements(By.XPath(".//tr"));

                foreach (IWebElement element in elements)
                {
                    string name = element.FindElement(By.XPath(".//td[1]")).Text;
                    string state = element.FindElement(By.XPath(".//td[2]")).Text;
                    string enable = element.FindElement(By.XPath(".//td[4]")).Text;
                    string description = element.FindElement(By.XPath(".//td[5]")).Text;
                projectCache.Add(new ProjectData()
                    {
                        Name = name,
                        State = state,
                        Enable = enable,
                        Description = description
                    });
                }

            //}
            return new List<ProjectData>(projectCache);
        }

        public void Delete(ProjectData project)
        {
            manager.Navigator.GoToProjPage();
            OpenProjectForm(project.Name);
            DeleteProject();
        }

        public void DeleteProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();

            if (manager.Navigator.MyPage("manage_proj_delete.php"))
            {
                driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            }        

        }

        public void OpenProjectForm(string name)
        {
            driver.FindElement(By.LinkText(name)).Click();
        }

        public void SubmitCreate()
        {
            driver.FindElement(By.CssSelector("input.btn")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            Type(By.Id("project-name"), project.Name);
            SelectByText(By.Id("project-status"), project.State);
            //вынести метод с проверкой             driver.FindElement(By.Id("project-inherit-global")).Click();
            SelectByText(By.Id("project-view-state"), project.Enable);
            Type(By.Id("project-description"), project.Description);

        }

        public void CreateNewProject()
        {
            driver.FindElement(By.CssSelector("button.btn")).Click();
        }
    }
}
