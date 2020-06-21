using AutoFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace AutoFramework.Base
{
    public class TestInitialize : Steps
    {
        private readonly ParallelConfig _parallelConfig;
        public TestInitialize(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public void InitializeSetting()
        {
            ConfigReader.SetFrameworkSettings();
            _parallelConfig.Driver = CreateBrowser(GetDriverOption(BrowserType.Chrome));
            _parallelConfig.Driver.Navigate().GoToUrl(Settings.AUT);
            _parallelConfig.Driver.Manage().Window.Maximize();
        }

        public RemoteWebDriver CreateBrowser(DriverOptions driverOptions)
        {


            switch (driverOptions)
            {
                case InternetExplorerOptions internetExplorerOptions:

                    driverOptions = new InternetExplorerOptions();
                    break;

                case FirefoxOptions firefoxOptions:

                    firefoxOptions.AddAdditionalCapability(CapabilityType.BrowserName, "firefox");
                    firefoxOptions.AddAdditionalCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    firefoxOptions.BrowserExecutableLocation = "";
                    break;

                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    break;
            }
            _parallelConfig.Driver = new RemoteWebDriver(new Uri("http://192.168.0.5:4444/wd/hub"), driverOptions.ToCapabilities());
            return _parallelConfig.Driver;
        }

        public DriverOptions GetDriverOption(BrowserType browsertype)
        {
            switch (browsertype)
            {
                case BrowserType.Chrome:
                    return new ChromeOptions();
                case BrowserType.FireFox:
                    return new FirefoxOptions();
                case BrowserType.IE:
                    return new InternetExplorerOptions();
                default:
                    return new ChromeOptions();
            }
        }


    }
}
