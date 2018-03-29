using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreateTests : TestBase
    {
        [Test]
        public void ProjectCreateTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Test",
                State = "выпущен",
                Enable = "публичная",
                Description = "test"
            };

            if (app.Project.Exists(project.Name)) { app.Project.Delete(project); }

            List<ProjectData> oldList = app.Project.GetProjectList();
            
            app.Project.Create(project);

            List<ProjectData> newList = app.Project.GetProjectList();
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);

        }
        
    }
}
