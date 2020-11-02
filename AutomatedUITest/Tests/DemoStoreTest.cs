using AutomatedUITest.Builders;
using AutomatedUITest.Fixtures;
using AutomatedUITest.PageObjects;
using FluentAssertions;
using System;
using Xunit;

namespace AutomatedUITest
{
    [Collection("Driver")]
    public class DemoStoreTest : IDisposable
    {
        private readonly EnvironmentFixture _fixture;
        private readonly InitialPage _initialPage;
        private readonly ResultSearchPage _resultSearchPage;
        private readonly ViewCartPage _viewCartPage;
        private Product _product;
        private readonly CheckoutPage _checkoutPage;
        private Customer _customer;
        private readonly DetailsProductPage _detailsProductPage;

        public DemoStoreTest(EnvironmentFixture fixture)
        {
            _fixture = fixture;
            _initialPage = new InitialPage(_fixture.Driver);
            _resultSearchPage = new ResultSearchPage(_fixture.Driver);
            _viewCartPage = new ViewCartPage(_fixture.Driver);
            _checkoutPage = new CheckoutPage(_fixture.Driver);
            _detailsProductPage = new DetailsProductPage(_fixture.Driver);
        }
        [Fact]
        public void FinalizeOrderValidatingRecaptchaMessage()
        {
            _product = ProductBuilder.New().Build();
            _customer = CustomerBuilder.New().Build();
            _initialPage.Visit();
            _initialPage.SearchProduct(_product.Title);
            _resultSearchPage.SelectFirstItemOnPage();
            _detailsProductPage.AddToCart();
            _detailsProductPage.ViewCart();
            _viewCartPage.GetProductTitle().Should().Be(_product.Title);
            _viewCartPage.GetProductUnitPrice().Should().Be(_product.UnitPrice);
            _viewCartPage.ProceedToCheckout();
            _checkoutPage.DoCheckout(_customer);

        }

        public void Dispose()
        {
            _fixture?.Dispose();
        }
    }
}
