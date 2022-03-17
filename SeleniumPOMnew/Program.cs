using NUnit.Framework;
using OpenQA.Selenium.Chrome;
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
            // Handling webdriver through DriverManager. 
            new DriverManager().SetUpDriver(new ChromeConfig());

            // Assigning the instance of ChromeDriver to Driver property. 
            // Initializing URL using the default Url property 
            WebD.Driver = new ChromeDriver() { Url = "https://demosite.executeautomation.com/Login.html" };
        }
      
        
        [Test]
        public void Login()
        {
            // Creating object to the LoginPO. 
            LoginPO lp = new LoginPO();
            lp.EnterCred("Admin", "password");
            
            // Assigning object reference for the HomePO instance returned from ClickLogin() method. 
            HomePO hp = lp.ClickLogin();
            hp.CaptureForm("C", "S");
        }

        [TearDown]
        // Using Lambda expression to quit the webdriver insances in TearDown method. 
        public void TearDown() => WebD.Driver.Quit();
    }
}
