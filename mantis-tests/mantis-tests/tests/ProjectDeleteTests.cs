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
                Name = "dfdf"
            };
            
            if (!app.Project.Exists(project.Name)) { app.Project.Create(project); }
            List<ProjectData> oldList = app.Project.GetProjectList();

            app.Project.Delete(project);

            List<ProjectData> newList = app.Project.GetProjectList();
            oldList.Remove(project);
            Assert.AreEqual(oldList, newList);

            foreach (ProjectData p in newList)
            {
                Assert.AreNotEqual(p.Name, project.Name);
            }
        }
    }
}
