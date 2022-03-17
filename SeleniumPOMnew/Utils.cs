using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM
{
    internal static class Utils
    {
        /// <summary>
        /// Custom extension method clear and enters specified value into a inputbox webelement 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }
        
        /// <summary>
        /// Customer extension method clicks on the webelement 
        /// </summary>
        /// <param name="element"></param>
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Custom extension method selects specified visible text from the dropdown list
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDD(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
    }
}
