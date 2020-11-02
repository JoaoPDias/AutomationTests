using OpenQA.Selenium;

namespace AutomatedUITest.PageObjects
{
    public class DetailsProductPage : Page
    {
        private readonly By _byButtonToAddToCart;
        private readonly By _byConfirmModal;
        private By _byButtonMyCart;
        private By _byButtonToViewCart;

        public DetailsProductPage(IWebDriver driver) : base(driver)
        {
            _byButtonMyCart = By.Id("cart_status_8");
            _byButtonToViewCart = By.XPath("//div[@id='dropdown_8']//div[@class='ty-float-left']/a");
            _byButtonToAddToCart = By.XPath("//button[(contains(concat(' ',normalize-space(@class),' '),' ty-btn__add-to-cart '))]");
            _byConfirmModal = By.XPath(" //body/div[5]/div[1]/div[1]");
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
