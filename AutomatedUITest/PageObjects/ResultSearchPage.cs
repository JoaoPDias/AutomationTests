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
        private By _byButtonMyCart;
        private By _byButtonToViewCart;
        private By _byConfirmModal;

        public ResultSearchPage(IWebDriver driver) : base(driver)
        {
            _byItemFoundGrid = By.XPath("//div[@class=\"cm-gallery-item cm-item-gallery\"]/a");
            _byButtonToAddToCart =
                By.XPath("//button[(contains(concat(' ',normalize-space(@class),' '),' ty-btn__add-to-cart '))]");
            _byButtonMyCart = By.Id("cart_status_8");
            _byButtonToViewCart = By.XPath("//div[@id='dropdown_8']//div[@class='ty-float-left']/a");
            _byConfirmModal = By.XPath(" //body/div[5]/div[1]/div[1]");
        }

        public void SelectFirstItemOnPage()
        {
            PerformClick(_byItemFoundGrid);
        }

        public void AddToCart()
        {
            PerformClick(_byButtonToAddToCart);
            WaitUntilElementIsInvisible(_byConfirmModal);
        }

        public void ViewCart()
        {
            PerformClick(_byButtonMyCart);
            PerformClick(_byButtonToViewCart);
        }
    }
}
