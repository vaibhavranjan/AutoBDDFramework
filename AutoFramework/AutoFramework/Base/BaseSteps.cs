using AutoFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;

namespace AutoFramework.Base
{
    public class BaseSteps
    {
        public readonly ParallelConfig _parallelConfig;

        public BaseSteps(ParallelConfig parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        public BaseSteps()
        {

        }

        public TPage GetPageInstance<TPage>() where TPage : BaseSteps, new()
        {
            //C# Reflection concept is used
            return (TPage)Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BaseSteps
        {
            return (TPage)this;
        }
    }
}
