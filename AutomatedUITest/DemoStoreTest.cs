using System;
using System.Net.Http.Headers;
using AutomatedUITest.Fixtures;
using AutomatedUITest.PageObjects;
using FluentAssertions;
using Xunit;

namespace AutomatedUITest
{
    [Collection("Driver")]
    public class DemoStoreTest:IDisposable
    {
        private EnvironmentFixture _fixture;
        private InitialPage _initialPage;
        private ResultSearchPage _resultSearchPage;
        private ViewCartPage _viewCartPage;
        private Product _product;
        private CheckoutPage _checkoutPage;
        private Customer _customer;

        public DemoStoreTest(EnvironmentFixture fixture)
        {
            _fixture = fixture;
            _initialPage = new InitialPage(_fixture.Driver);
            _resultSearchPage = new ResultSearchPage(_fixture.Driver);
            _viewCartPage = new ViewCartPage(_fixture.Driver);
            _checkoutPage = new CheckoutPage(_fixture.Driver);
        }
        [Fact]
        public void FinalizeOrderValidatingRecaptchaMessage()
        {
            _product = ProductBuilder.New().Build();
            _customer = CustomerBuilder.New().Build();
            _initialPage.Visit();
            _initialPage.SearchProduct(_product.Title);
            _resultSearchPage.SelectFirstItemOnPage();
            _resultSearchPage.AddToCart();
            _resultSearchPage.ViewCart();
            _viewCartPage.GetProductTitle().Should().Be(_product.Title);
            _viewCartPage.GetProductUnitPrice().Should().Be(_product.UnitPrice);
            _viewCartPage.ProceedToCheckout();
            _checkoutPage.DoCheckout();

        }

        public void Dispose()
        {
            _fixture?.Dispose();
        }
    }
}
