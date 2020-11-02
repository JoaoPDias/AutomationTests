using FluentAssertions;
using OpenQA.Selenium;

namespace AutomatedUITest.PageObjects
{
    public class CheckoutPage : Page
    {
        private readonly By _byCustomerAddressInput;
        private readonly By _byCustomerPostalCodeInput;
        private readonly By _byCustomerNameInput;
        private readonly By _byCustomerPhoneInput;
        private readonly By _byCustomerEmailInput;
        private readonly By _byPaymentByPhoneOrderingRadioButton;
        private readonly By _byCustomerPhoneConfirmation;
        private readonly By _byAcceptTermsCheckbox;
        private By _byConfirmOrder;
        private By _byRobotValidationText;

        public CheckoutPage(IWebDriver webDriver) : base(webDriver)
        {
            _byCustomerAddressInput = By.Id("litecheckout_s_address");
            _byCustomerPostalCodeInput = By.Id("litecheckout_s_zipcode");
            _byCustomerNameInput = By.Id("litecheckout_fullname");
            _byCustomerPhoneInput = By.Id("litecheckout_phone");
            _byCustomerEmailInput = By.Id("litecheckout_email");
            _byPaymentByPhoneOrderingRadioButton = By.XPath("//div[@class='litecheckout__shipping-method litecheckout__field litecheckout__field--xsmall'][4]");
            _byCustomerPhoneConfirmation = By.Id("customer_phone");
            _byAcceptTermsCheckbox = By.Name("accept_terms");
            _byConfirmOrder = By.Id("litecheckout_place_order");
            _byRobotValidationText = By.XPath(" //p[contains(text(),'Please confirm you are not a robot.')]");

        }
        //
        public void DoCheckout(Customer customer)
        {
            PerformSendKeys(_byCustomerAddressInput, customer.Address);
            PerformSendKeys(_byCustomerPostalCodeInput, customer.PostalCode);
            PerformSendKeys(_byCustomerNameInput, customer.Name);
            PerformSendKeys(_byCustomerPhoneInput, customer.Phone);
            PerformSendKeys(_byCustomerEmailInput, customer.Email);
            PerformClickWhenElementIsVisible(_byPaymentByPhoneOrderingRadioButton);
            PerformSendKeys(_byCustomerPhoneConfirmation, customer.Phone);
            PerformClick(_byAcceptTermsCheckbox);
            PerformClickWhenElementIsVisible(_byConfirmOrder);
            GetTextFromElement(_byRobotValidationText).Should().NotBeNullOrEmpty();
        }
    }
}