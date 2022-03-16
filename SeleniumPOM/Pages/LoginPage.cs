using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace SeleniumPOM.Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(WebD.Driver, this);
        }

        [FindsBy(How=How.Name,Using = "UserName")]
        public IWebElement TxtUserName { get; set; }

        [FindsBy(How =How.Name, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How =How.XPath,Using = "//input[@value='Login']")]
        public IWebElement BtnLogin { get; set; }

        public void EnterCred(string uName, string passWord)
        {
            TxtUserName.SendKeys(uName);
            TxtPassword.SendKeys(passWord);
        }
        public HomePage ClickLogin()
        {
            BtnLogin.Submit();
            return new HomePage();
        }
    }
}
