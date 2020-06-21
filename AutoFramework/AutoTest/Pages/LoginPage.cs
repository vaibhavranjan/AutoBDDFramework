using AutoFramework.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTest.Pages
{
    public class LoginPage : BaseSteps
    {
        public LoginPage(ParallelConfig parallelConfig) : base(parallelConfig)
        {

        }

        public IWebElement txtUserName => _parallelConfig.Driver.FindElement(By.Id("UserName"));
        public IWebElement txtPassword => _parallelConfig.Driver.FindElement(By.Id("Password"));
        public IWebElement txtLoginButton => _parallelConfig.Driver.FindElement(By.CssSelector("input.btn"));

        public void Login(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);           
            
        }

        public HomePage ClickLoginButton()
        {
            txtLoginButton.Submit();
            return new HomePage(_parallelConfig);
        }
    }
}
