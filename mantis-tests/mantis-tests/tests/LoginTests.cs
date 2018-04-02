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
    public class LoginTests : TestBase
    {
        
        [Test]
        public void LoginTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "23102310"
            };

            app.Auth.Login(account);            
            app.Auth.Logout();
        }
    }
}
