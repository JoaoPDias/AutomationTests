using AutomatedUITest.PageObjects;
using OpenQA.Selenium;

namespace AutomatedUITest
{
    public class ViewCartPage:Page
    {
        private By _byProductUnitPrice;
        private By _byProductTitle;

        public ViewCartPage(IWebDriver webDriver) : base(webDriver)
        {
            _byProductUnitPrice = By.XPath("//span[@class='ty-sub-price'][2]");
            _byProductTitle = By.XPath("//a[@class='ty-cart-content__product-title']");
        }

        public void ProceedToCheckout()
        {
            
        }

        public bool ValidUnitPrice(string unitPrice)
        {
            string _productValue = 
        }
    }
}