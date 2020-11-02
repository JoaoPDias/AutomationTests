using OpenQA.Selenium;

namespace AutomatedUITest.PageObjects
{
    public class ViewCartPage : Page
    {
        private By _byProductUnitPrice;
        private By _byProductTitle;
        private By _byButtonProceedToCheckout;

        public ViewCartPage(IWebDriver webDriver) : base(webDriver)
        {
            _byProductUnitPrice = By.XPath("//span[@class='ty-sub-price'][2]");
            _byProductTitle = By.XPath("//a[@class='ty-cart-content__product-title']");
            _byButtonProceedToCheckout = By.XPath("//div[@class='buttons-container ty-cart-content__top-buttons clearfix']/div[@class='ty-float-right ty-cart-content__right-buttons']");
        }

        public void ProceedToCheckout()
        {
            PerformClick(_byButtonProceedToCheckout);
        }

        public string GetProductUnitPrice()
        {
            return GetTextFromElement(_byProductUnitPrice);
        }
        public string GetProductTitle()
        {
            return GetTextFromElement(_byProductTitle);
        }
    }
}