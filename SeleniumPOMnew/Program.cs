using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMnew;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumPOMnew
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

            // Initializing data from specified sheet of the excel sheet. 
            ExcelUtil.ExceltoInternal(@"E:/SeleniumSln/SeleniumPOMnew/Data/ExcelData.xlsx", "Cred");
            
            // Assigning the instance of ChromeDriver to Driver property. 
            // Initializing URL using the default Url property 
            WebD.Driver = new ChromeDriver() { Url = "https://parabank.parasoft.com/parabank/index.htm" };
        }
      
        
        [Test]
        public void Login()
        {
            // Creating object to the LoginPO. 
            LoginPO lp = new LoginPO();
            
            // Entering login credentials from excel file. 
            lp.EnterCred(ExcelUtil.ReadData(1, "enter_uName"), ExcelUtil.ReadData(1, "enter_Pwd"));

			// Assigning object reference for the HomePO instance returned from ClickLogin() method. 
			//HomePO hp = lp.ClickLogin();
			//hp.CaptureForm("C", "S");
		}

		[TearDown]
        // Using Lambda expression to quit the webdriver insances in TearDown method. 
        public void TearDown() => WebD.Driver.Dispose();
    }
}
