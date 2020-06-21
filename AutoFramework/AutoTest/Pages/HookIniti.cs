using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AutoFramework.Base;
using AutoFramework.Config;
using System;
using System.Reflection;
using TechTalk.SpecFlow;
using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace AutoTest.Pages
{
    [Binding]
    public class HookIniti : TestInitialize
    {
        #region varibale
        private static ExtentReports extent;
        private ExtentTest scenario;
        private static ExtentTest feature;
        private static ExtentHtmlReporter htmlReporter;
        private readonly ParallelConfig _parallelConfig;
        private readonly ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;

        private static ExtentKlovReporter klov;
        #endregion

        public HookIniti(ParallelConfig parallelConfig, FeatureContext featureContext,
            ScenarioContext scenarioContext) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;
        }

        [AfterStep]
        public void AfterStepTest()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.Text;

            //PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            //MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            //object TestResult = getter.Invoke(_scenarioContext, null);

            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else if (_scenarioContext.TestError != null)
            {
                var mediaEntity = _parallelConfig.CaptureScreenshotAndReturn(_scenarioContext.ScenarioInfo.Title.Trim());

                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message, mediaEntity);
            }

            if (_scenarioContext.ScenarioExecutionStatus.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition is not implemented");
                else if (stepType == "When")
                    scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition is not implemented");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition is not implemented");
                else if (stepType == "And")
                    scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition is not implemented");
            }
        }

        [BeforeTestRun]
        public static void BeforeTest()
        {
            string filename = "ExtentReporting" + DateTime.Now + ".html";
            htmlReporter = new ExtentHtmlReporter(Settings.LogPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            klov = new ExtentKlovReporter();

            extent.AttachReporter(htmlReporter);
        }

        [BeforeScenario]
        public void BeforeScenTest()
        {
            InitializeSetting();
            feature = extent.CreateTest<Feature>(_featureContext.FeatureInfo.Title);
            scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterTestRun]
        public static void AfterTest()
        {
            extent.Flush();
        }
    }
}
