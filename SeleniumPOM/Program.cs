using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumPOM
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        [SetUp]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            WebD.Driver = new ChromeDriver() { Url = "https://demosite.executeautomation.com/Login.html" };
        }
      
        
        [Test]
        public void Login()
        {
            LoginPO lp = new LoginPO();
            //PageFactory.InitElements(WebD.Driver, lp);
            lp.EnterCred("Admin", "password");
            HomePO hp = lp.ClickLogin();
            //PageFactory.InitElements(WebD.Driver, hp);
            hp.CaptureForm("C", "S");
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}
