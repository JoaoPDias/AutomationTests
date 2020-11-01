using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
            Driver = webDriver??throw new ArgumentNullException("WebDriver is null");
            IClock clock = new SystemClock();
            Wait = new WebDriverWait(clock,Driver,
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







        #endregion;
    }
}
