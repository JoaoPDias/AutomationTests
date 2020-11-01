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
        public DemoStoreTest(EnvironmentFixture fixture)
        {
            _fixture = fixture;
            _initialPage = new InitialPage(_fixture.Driver);
            _resultSearchPage = new ResultSearchPage(_fixture.Driver);
        }
        [Fact]
        public void FinishShipping()
        {
            _product = ProductBuilder.New().Build();
            _initialPage.Visit();
            _initialPage.SearchProduct(_product.Name);
            _resultSearchPage.SelectFirstItemOnPage();
            _resultSearchPage.AddToCart();
            _resultSearchPage.ViewCart();
            _viewCartPage.ProceedToCheckout();

        }

        public void Dispose()
        {
            _fixture?.Dispose();
        }
    }
}
