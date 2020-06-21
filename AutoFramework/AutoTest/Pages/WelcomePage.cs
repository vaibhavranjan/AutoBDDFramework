using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest.Pages
{
    public class WelcomePage : BaseSteps
    {

        public WelcomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }
        public IWebElement loginLink => _parallelConfig.Driver.FindElement(By.LinkText("Login"));

        public LoginPage ClickLoginLink()
        {
            loginLink.Click();
            return new LoginPage(_parallelConfig);
        }

        public void CheckLoginLinkIsPresent()
        {
            loginLink.AssertElementPresent();
        }
    }
}
