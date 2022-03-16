using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumPOM.Pages;
using System.Linq;

namespace SeleniumPOM
{
    enum Locator
    {
        Id, Name, XPath, ClassName, LinkText, PartialLinkText, TagName, CssSelector
    }
    class Reuse
    {
        // Method to enter text 
        public void EnterText(string element,Locator locator, string value)
        {
            IWebElement _temp;
            switch (locator)
            {
                case Locator.Id:
                    _temp = WebD.Driver.FindElement(By.Id(element));
                    _temp.Clear();
                    _temp.SendKeys(value);
                    Assert.That(value, Is.EqualTo(_temp.GetAttribute("value")));
                    break;
                case Locator.Name:
                    _temp = WebD.Driver.FindElement(By.Name(element));
                    _temp.Clear();
                    _temp.SendKeys(value);
                    Assert.That(value, Is.EqualTo(_temp.GetAttribute("value")));
                    break;
            }            
        }

        public void Click(string element, Locator locator)
        {
            switch (locator)
            {
                case Locator.Id:
                    WebD.Driver.FindElement(By.Id(element)).Click();
                    break;
                case Locator.Name:
                    WebD.Driver.FindElement(By.Name(element)).Click();
                    break;
                case Locator.XPath:
                    WebD.Driver.FindElement(By.XPath(element)).Click();
                    break;
            }
        }
        public void SelectDD(string element, Locator locator, string value)
        {
            IWebElement _temp;
            switch (locator)
            {
                case Locator.Id:
                    _temp = WebD.Driver.FindElement(By.Id(element));
                    new SelectElement(_temp).SelectByText(value);
                    Assert.That(value, Is.EqualTo(new SelectElement(_temp).AllSelectedOptions.SingleOrDefault().Text));
                    break;
                case Locator.Name:
                    _temp = WebD.Driver.FindElement(By.Name(element));
                    new SelectElement(_temp).SelectByText(value);
                    Assert.That(value, Is.EqualTo(new SelectElement(_temp).AllSelectedOptions.SingleOrDefault().Text));
                    break;
            }
            
        }
    }
}
