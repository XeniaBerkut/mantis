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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToProjPage()
        {
            if (driver.Url == baseURL + "manage_proj_page.php")
            {
                return;
            }
            GoToOverVWPage();
            driver.FindElement(By.LinkText("Управление проектами")).Click();
            //driver.Navigate().GoToUrl(baseURL + "manage_proj_page.php");
            //return this;
        }

        public void GoToOverVWPage()
        {
            if (driver.Url == baseURL + "manage_overview_page.php")
            {
                return;
            }
            driver.FindElement(By.CssSelector("i.fa-gears")).Click();
            //driver.FindElements(By.CssSelector("span.menu-text"))[6].Click();
            
        }

        public bool MyPage(string path)
        {
            if (driver.Url == baseURL + path)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GoToLoginPage()
        {
             if (driver.Url == baseURL + "login_page.php")
                {
                    return;
                }

            driver.Navigate().GoToUrl(baseURL + "login_page.php");
        }
    }
}
