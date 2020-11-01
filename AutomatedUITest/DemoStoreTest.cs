using System;
using AutomatedUITest.Fixtures;
using AutomatedUITest.PageObjects;
using iClipsTest.Fixtures;
using Xunit;

namespace AutomatedUITest
{
    [Collection("Driver")]
    public class DemoStoreTest:IDisposable
    {
        private EnvironmentFixture _fixture;
        private InitialPage _initialPage;

        public DemoStoreTest(EnvironmentFixture fixture)
        {
            _fixture = fixture;
            _initialPage = new InitialPage(_fixture.Driver);
        }
        [Fact]
        public void FinishShipping()
        {
            _initialPage.Visit();
            _initialPage.SendProductToSearch("H.264 Megapixel Surveillance Camera TL-SC3430");

        }

        public void Dispose()
        {
            _fixture?.Dispose();
        }
    }
}
