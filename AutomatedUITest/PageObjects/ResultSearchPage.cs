using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace AutomatedUITest.PageObjects
{
    public class ResultSearchPage : Page
    {
        private By _byItemFoundGrid;
        private By _byButtonToAddToCart;
        private By _byButtonToCheckout;

        public ResultSearchPage(IWebDriver driver) : base(driver)
        {
            _byItemFoundGrid = By.XPath("//div[@class=\"cm-gallery-item cm-item-gallery\"]/a");
            _byButtonToAddToCart =
                By.XPath("//button[(contains(concat(' ',normalize-space(@class),' '),' ty-btn__add-to-cart '))]");
            _byButtonToCheckout = By.XPath("//div[@class='ty-float-right']/button");
        }

        public void SelectFirstItemOnPage()
        {
            PerformClick(_byItemFoundGrid);
        }

        public void AddToCart()
        {
            PerformClick(_byButtonToAddToCart);
        }

        public void Checkout()
        {
            PerformClick(_byButtonToCheckout);
        }
    }
}
