using AutomatedUITest.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomatedUITest.Fixtures
{
    public class EnvironmentFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public EnvironmentFixture()
        {
            this.Driver = GetWebDriver(DriverOption.Chrome);
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.Driver.Manage().Window.Maximize();
            this.Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);

        }
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private IWebDriver GetWebDriver(DriverOption driverOption)
        {
            switch (driverOption)
            {

                case DriverOption.Chrome:
                    {
                        var chromeOpts = new ChromeOptions();
                        //chromeOpts.AddArgument("--headless");
                        return new ChromeDriver(TestHelper.BinFolder, chromeOpts);
                    }
                case DriverOption.Firefox:
                    {
                        var firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArgument("--headless");
                        return new FirefoxDriver(TestHelper.BinFolder, firefoxOptions);
                    }
                default: throw new NotSupportedException("not supported browser: <null>");
            }
        }
    }
}
