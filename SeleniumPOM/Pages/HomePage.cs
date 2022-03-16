using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumPOM.Pages
{
    public class HomePage
    {
        public HomePage()
        {
            PageFactory.InitElements(WebD.Driver, this);
        }

        [FindsBy(How = How.Name, Using = "Initial")]
        public IWebElement TxtInitial { get; set; }

        [FindsBy(How =How.Name,Using = "FirstName")]
        public IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='female']")]
        public IWebElement RdGenger { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement BtnSave { get; set; }

        public void CaptureUserForm(string initial, string fName)
        {
            TxtInitial.SendKeys(initial);
            TxtFirstName.SendKeys(fName);
            RdGenger.Click();
            BtnSave.Submit();
        }
    }
}
