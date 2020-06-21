using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AutoFramework.Base;
using AutoTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Runtime.InteropServices.ComTypes;
using NUnit.Framework.Internal;


namespace AutoTest.Steps
{
    [Binding]
    public class ExtendedSteps : BaseSteps
    {
        public TestInitialize testInit;
        public ExtendedSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
        }
        
        [Given(@"I navigate to EA App url and I see Welcome page is loaded")]
        public void GivenINavigateToEAAppUrlAndISeeWelcomePageIsLoaded()
        {
            _parallelConfig.currentPage = new WelcomePage(_parallelConfig);
            _parallelConfig.currentPage.As<WelcomePage>().CheckLoginLinkIsPresent();
        }

        [When(@"i click (.*) link")]
        public void WhenIClickLink(string linkName)
        {
            if (linkName == "login")
                _parallelConfig.currentPage = _parallelConfig.currentPage.As<WelcomePage>().ClickLoginLink();
            else if (linkName == "employeelist")
                _parallelConfig.currentPage = _parallelConfig.currentPage.As<HomePage>().ClickEmployeeListLink();
        }

        [When(@"I click (.*) button")]
        public void WhenIClickButton(string button)
        {
            if (button == "login")
                _parallelConfig.currentPage = _parallelConfig.currentPage.As<LoginPage>().ClickLoginButton();
            else if (button == "createnew")
                _parallelConfig.currentPage = _parallelConfig.currentPage.As<EmployeeListPage>().ClickCreateNewButton();
            else if (button == "create")
                _parallelConfig.currentPage.As<CreateEmployeePage>().ClickCreateButton();
        }

        
        public void AfterScenarioTest()
        {
            _parallelConfig.Driver.Close();
            _parallelConfig.Driver.Quit();
        }

    }
}

