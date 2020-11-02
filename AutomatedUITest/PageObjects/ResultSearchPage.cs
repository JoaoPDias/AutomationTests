using OpenQA.Selenium;

namespace AutomatedUITest.PageObjects
{
    public class ResultSearchPage : Page
    {
        private readonly By _byItemFoundGrid;

        public ResultSearchPage(IWebDriver driver) : base(driver)
        {
            _byItemFoundGrid = By.XPath("//div[@class='cm-gallery-item cm-item-gallery']/a");
        }

        public void SelectFirstItemOnPage()
        {
            PerformClick(_byItemFoundGrid);
        }
    }
}
