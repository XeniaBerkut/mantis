using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssue : TestBase
    {
        [Test]
        public void AddNewIssueTest()
        {
            ProjectData project = new ProjectData()
            {
                Name = "Test"
            };

            IssueData issueData = new IssueData()
            {
                Summary = "some short text",
                Description = "some long text",
                Category = "General"
            };

            List<ProjectData> list = app.API.GetProjects();
            app.API.CreateNewIssue(project, issueData);
        }
    }
}
