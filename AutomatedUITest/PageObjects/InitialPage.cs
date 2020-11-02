using AutomatedUITest.Helpers;
using OpenQA.Selenium;

namespace AutomatedUITest.PageObjects
{
    public class InitialPage : Page
    {
        private readonly By _bySearchInputBox;
        private By _bySearchButton;

        public InitialPage(IWebDriver driver) : base(driver)
        {
            _bySearchInputBox = By.Id("search_input");
            _bySearchButton = By.XPath("//button[@class=\"ty-search-magnifier\"]");
        }

        public void SearchProduct(string productName)
        {
            PerformSendKeys(_bySearchInputBox, productName);
            PerformClick(_bySearchButton);
        }

        public void Visit() => Driver.Navigate().GoToUrl(ConfigurationEnviroment.url);
    }
}
