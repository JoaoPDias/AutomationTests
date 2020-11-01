using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutomatedUITest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomatedUITest.PageObjects
{
    public class InitialPage:Page
    {
        [FindsBy(How = How.Id, Using = "search_input")]
        private IWebElement _searchInputBox;

        public InitialPage(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public void SendProductToSearch(string productName) => PerformSendKeys(_searchInputBox,productName);
        public void Visit() => Driver.Navigate().GoToUrl(ConfigurationEnviroment.url);
    }
}
