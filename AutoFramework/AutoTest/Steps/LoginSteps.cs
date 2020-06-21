using AutoFramework.Base;
using AutoTest.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace AutoTest.Steps
{
    [Binding]
    public class LoginSteps : BaseSteps
    {
        public LoginSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        [Then(@"I can see login Page")]
        public void ThenICanSeeLoginPage()
        {
            Console.WriteLine("Login page is loaded");
        }

        [When(@"I enter userName and Password")]
        public void WhenIEnterUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.currentPage.As<LoginPage>().Login(data.userName, data.Password);

            //currentPage.As<LoginPage>().Login(Settings.Username, Settings.Passwrod);
        }

        [Then(@"I should see user is logged in")]
        public void ThenIShouldSeeUserIsLoggedIn()
        {
            bool isuserDisplayed = _parallelConfig.currentPage.As<HomePage>().IsLoggedInUserDisplayed();
            Assert.IsTrue(isuserDisplayed);
        }
    }
}
