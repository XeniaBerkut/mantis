using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeleteTests : TestBase
    {
        [Test]
        public void ProjectDeleteTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "MantisTest"
            };

            //if (!app.Project.Exists(project.Name)) { app.Project.Create(project); }
            if (!app.Project.Exists(project.Name))
            {
                app.API.CreateProject(project);
                app.Navigator.RefreshPage();
            }

            //List<ProjectData> oldList = app.Project.GetProjectList();
            List<ProjectData> oldList = app.API.GetProjects();
            app.Project.Delete(project);

            //List<ProjectData> newList = app.Project.GetProjectList();
            List<ProjectData> newList = app.API.GetProjects();
            oldList.Remove(project);
            Assert.AreEqual(oldList, newList);

            foreach (ProjectData p in newList)
            {
                Assert.AreNotEqual(p.Name, project.Name);
            }
        }
    }
}
