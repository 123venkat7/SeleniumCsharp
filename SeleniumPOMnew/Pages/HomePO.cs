using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOMnew
{
    internal class HomePO
    {
        // Default Constructor initializing the elements in this(HomePO) Page using PageFactory class. 
        public HomePO() => PageFactory.InitElements(WebD.Driver, this);

        [FindsBy(How = How.Name, Using = "Initial")]
        public IWebElement TxtInitial { get; set; }

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement TxtFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='female']")]
        public IWebElement RdGenger { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement BtnSave { get; set; }

        // Method to capture the userform 
        public void CaptureForm(string initial, string fName)
        {
            TxtInitial.EnterText(initial);
            TxtFirstName.EnterText(fName);
            RdGenger.Clicks();
            BtnSave.Clicks();
        }
    }
}
