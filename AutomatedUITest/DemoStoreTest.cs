using System;
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

        public DemoStoreTest(EnvironmentFixture fixture)
        {
            _fixture = fixture;
            _initialPage = new InitialPage(_fixture.Driver);
            _resultSearchPage = new ResultSearchPage(_fixture.Driver);
        }
        [Fact]
        public void FinishShipping()
        {
            _initialPage.Visit();
            _initialPage.SearchProduct("H.264 Megapixel Surveillance Camera TL-SC3430");
            _resultSearchPage.SelectFirstItemOnPage();
            _resultSearchPage.AddToCart();
            _resultSearchPage.Checkout();

        }

        public void Dispose()
        {
            _fixture?.Dispose();
        }
    }
}
