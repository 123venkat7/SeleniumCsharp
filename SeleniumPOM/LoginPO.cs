using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM
{
    internal class LoginPO
    {
        public LoginPO()
        {
            PageFactory.InitElements(WebD.Driver, this);
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement TxtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Login']")]
        public IWebElement BtnLogin { get; set; }

        public void EnterCred(string uName, string password)
        {
            TxtUserName.EnterText(uName);
            TxtPassword.EnterText(password);
        }

        public HomePO ClickLogin()
        {
            BtnLogin.Clicks();
            return new HomePO();
        }
    }
}
