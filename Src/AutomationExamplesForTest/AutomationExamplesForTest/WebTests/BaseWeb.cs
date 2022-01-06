using AutomationExamplesForTest.Startup;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExamplesForTest.WebTests
{
    [TestFixture]
    public class BaseWeb : BaseFramework
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseWeb));

        protected string? BrowserType { get; set; }
        protected IWebDriver? Driver { get; set; }

        public BaseWeb()
        {
            BrowserType = InitFramework.Configuration?
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["BrowserType"].ToLower();
        }

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            base.OneTimeSetUp();
        }

        [OneTimeTearDown]
        public override void OneTimeTearDown()
        {
            base.OneTimeTearDown();
        }
    }
}