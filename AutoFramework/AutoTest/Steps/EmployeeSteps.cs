using AutoFramework.Base;
using AutoTest.Pages;
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
    public class EmployeeSteps : BaseSteps
    {
        public EmployeeSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        [When(@"i enter following details")]
        public void WhenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.currentPage.As<CreateEmployeePage>().EnterEmployeeDetails(data.Name, data.Salary.ToString()
                , data.DurationWorked.ToString(), data.Grade.ToString(), data.Email);
        }


        [Then(@"i can see Employee is added")]
        public void ThenICanSeeEmployeeIsAdded()
        {
            Console.WriteLine("Employee is added");
        }

    }
}
