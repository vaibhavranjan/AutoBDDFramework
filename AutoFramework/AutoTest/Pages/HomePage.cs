using AutoFramework.Base;
using AutoFramework.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest.Pages
{
    public class HomePage : BaseSteps
    {
        public HomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }
        public IWebElement EmployeeListLink => _parallelConfig.Driver.FindElement(By.LinkText("Employee List"));
        public IWebElement loggedInUser => _parallelConfig.Driver.FindElement(By.XPath("//a[contains(text(),'Hello admin!')]"));
        public IWebElement loggedInUser1 => _parallelConfig.Driver.FindElement(By.XPath($"//a[contains(text(),'Hello {Settings.Username}!')]"));

        public EmployeeListPage ClickEmployeeListLink()
        {
            EmployeeListLink.Click();
            return new EmployeeListPage(_parallelConfig);
        }

        public bool IsLoggedInUserDisplayed()
        {
            bool isDisplayed = loggedInUser.Displayed;
            return isDisplayed;
        }
    }
}
