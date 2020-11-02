using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AutomatedUITest.PageObjects
{
    public class Page
    {
        #region Attributes
        public IWebDriver Driver;
        protected WebDriverWait Wait;
        #endregion
        #region Construtor
        public Page(IWebDriver webDriver)
        {
            Driver = webDriver ?? throw new ArgumentNullException("WebDriver is null");
            IClock clock = new SystemClock();
            Wait = new WebDriverWait(clock, Driver,
                                     TimeSpan.FromSeconds(15),
                                     TimeSpan.FromSeconds(2));
        }
        #endregion
        #region General Methods

        protected void PerformClick(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).Click().Perform();
        }
        protected void PerformClick(By byElement)
        {
            IWebElement element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(byElement));
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).Click().Perform();
        }
        protected void PerformClickWhenElementIsVisible(By byElement)
        {
            IWebElement element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(byElement));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).DoubleClick().Perform();
        }

        protected void WaitUntilElementIsInvisible(By byElement)
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(byElement));
        }

        protected void PerformSendKeys(IWebElement element, string text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (InvalidElementStateException)
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(text);
            }
            catch (NoSuchElementException e)
            {
                throw e;
            }

        }
        protected void PerformSendKeys(By byElement, string text)
        {
            IWebElement element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(byElement));
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (InvalidElementStateException)
            {
                element.SendKeys(Keys.Control + "a");
                element.SendKeys(Keys.Delete);
                element.SendKeys(text);
            }
            catch (NoSuchElementException e)
            {
                throw e;
            }

        }


        protected string GetTextFromElement(By by)
        {
            IWebElement element = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            return element.Text;
        }



        #endregion;
    }
}
