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
    public class AdminHelper : HelperBase
    {
        private string baseURL;
        public AdminHelper (ApplicationManager manager, string baseURL)    : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {
            List<AccountData> accounts = new List<AccountData>();

            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "manage_user_page.php";
            IList<IWebElement> rows = driver.FindElements(By.CssSelector("tbody tr"));
            foreach (IWebElement row in rows)
            {
                IWebElement link = row.FindElement(By.TagName("a"));
                string name = link.Text;
                string href = link.GetAttribute("href");
                Match m = Regex.Match(href, @"\d+$");
                string id = m.Value;

                accounts.Add(new AccountData()
                { Name = name, Id = id });
            }

            return accounts;
        }

        public void DeleteAccount(AccountData account)
        {
            IWebDriver driver = OpenAppAndLogin();
            driver.Url = baseURL + "manage_user_edit_page.php? user_id = " + account.Id;
            driver.FindElement(By.CssSelector("input[value='Удалить учетную запись']"));
            if (MyPage("manage_user_delete.php"))
            { driver.FindElement(By.CssSelector("input[value='Удалить учетную запись']")); }
            
        }

        private IWebDriver OpenAppAndLogin()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "23102310"
            };

            IWebDriver driver = new SimpleBrowserDriver();
            driver.Url = baseURL + "login_page.php";

            Type(By.Id("username"), account.Name);
            driver.FindElement(By.CssSelector("input.btn")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.CssSelector("input.btn")).Click();
            return driver;
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
    }
}
