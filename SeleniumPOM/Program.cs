using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOM.Pages;

namespace SeleniumPOM
{
    public class Program
    {
        public static void Main(string[] args) { }
        [SetUp]
        public void SetUp ()
        {
            WebD.Driver = new ChromeDriver()
            {
                Url = "https://demosite.executeautomation.com/Login.html"
            };
        }
        [Test]
        public void Login()
        {
            LoginPage lp = new LoginPage();
            lp.EnterCred("Admin","password");
            HomePage hp = lp.ClickLogin();
            hp.CaptureUserForm("C", "V");
            hp.BtnSave.Submit();
        }
        [TearDown]
        public void TearDown() => WebD.Driver.Quit();
    }
}
