using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests 
{

    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        /*[TestFixtureSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("");
            app.Ftp.Upload("", null);
        }*/

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "Ксения",
                Password = "1111",
                Email = "1111@gmail.com"
            };
            string message = "Поздравляем! Вы успешно зарегистрированы. Для проверки адреса вам выслано подтверждающее письмо. Переход по ссылке, высланной в письме, активирует вашу учетную запись." 
                + "\r\n\r\n" + "У вас есть семь дней для подтверждения учётной записи. Если за это время вы не активируете её, зарегистрированная учётная запись может быть удалена.";


            List<AccountData> accounts = app.Admin.GetAllAccounts();

            AccountData existAccount = accounts.Find(x => x.Name == account.Name);
            app.Admin.DeleteAccount(existAccount);


            app.Registration.Register(account);

            string text = app.Registration.GetText("div.widget-main div");
            Assert.AreEqual(message, text);
            //System.Console.Out.WriteLine(text);

        }

        /*[TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("");
        }*/

    }
}
