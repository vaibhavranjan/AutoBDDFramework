using AutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest.Pages
{
    public class CreateEmployeePage : BaseSteps
    {
        public CreateEmployeePage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        public IWebElement nameField => _parallelConfig.Driver.FindElement(By.XPath("//input[@id='Name']"));
        public IWebElement SalaryField => _parallelConfig.Driver.FindElement(By.XPath("//input[@id='Salary']"));
        public IWebElement workDurationField => _parallelConfig.Driver.FindElement(By.XPath("//input[@id='DurationWorked']"));
        public IWebElement gradeField => _parallelConfig.Driver.FindElement(By.XPath("//input[@id='Grade']"));
        public IWebElement emailField => _parallelConfig.Driver.FindElement(By.XPath("//input[@id='Email']"));
        public IWebElement createButton => _parallelConfig.Driver.FindElement(By.XPath("//input[@value='Create']"));

        public void EnterEmployeeDetails(string name, string salary, string durationWorked,
            string grade,string email)
        {
            nameField.SendKeys(name);
            SalaryField.SendKeys(salary);
            workDurationField.SendKeys(durationWorked);
            gradeField.SendKeys(grade);
            emailField.SendKeys(email);

        }

        public void ClickCreateButton()
        {
            createButton.Submit();
        }
    }
}
