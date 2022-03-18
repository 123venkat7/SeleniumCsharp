using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMnew
{
    internal class LoginPO
    {
        // Default Constructor initializing the elements in this(LoginPO) Page using PageFactory class. 
        public LoginPO() => PageFactory.InitElements(WebD.Driver, this);

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement TxtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Log In']")]
        public IWebElement BtnLogin { get; set; }

        // Method to input Login credentials in the website. 
        public void EnterCred(string uName, string password)
        {
            TxtUserName.EnterText(uName);
            TxtPassword.EnterText(password);
        }

        // Method to return a new HomePO instance by clicking on Login button
        public HomePO ClickLogin()
        {
            BtnLogin.Clicks();
            return new HomePO();
        }
    }
}
