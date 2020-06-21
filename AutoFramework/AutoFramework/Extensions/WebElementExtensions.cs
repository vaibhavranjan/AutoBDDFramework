using AutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFramework.Extensions
{
    public static class WebElementExtensions
    {
        public static void SelectDropDownValue(this IWebElement element, string value)
        {
            SelectElement se = new SelectElement(element);
            se.SelectByText(value);
        }
        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element not present exception"));
        }
        public static string GetSelectedFirstDropDownValue(this IWebElement element)
        {
            SelectElement se = new SelectElement(element);
            return se.AllSelectedOptions.First().ToString();
        }
        public static IList<IWebElement> GetSelectedDropDownValue(this IWebElement element)
        {
            SelectElement se = new SelectElement(element);
            return se.AllSelectedOptions;
        }
        //public static void Hover(this IWebElement element)
        //{
        //    Actions actions = new Actions(DriverContext.Driver);
        //    actions.MoveToElement(element).Perform();
        //}
        public static bool IsElementPresent(IWebElement element)
        {
            try
            {
               bool ele = element.Displayed;
                return ele;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
