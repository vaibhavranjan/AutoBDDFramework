using AutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest.Pages
{

    public class EmployeeListPage : BaseSteps
    {
        public EmployeeListPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }
        public IWebElement searchName => _parallelConfig.Driver.FindElement(By.Name("searchTerm"));
        public IWebElement createNewButton => _parallelConfig.Driver.FindElement(By.LinkText("Create New"));

        public CreateEmployeePage ClickCreateNewButton()
        {
            createNewButton.Click();
            return new CreateEmployeePage(_parallelConfig);
        }
    }
}
