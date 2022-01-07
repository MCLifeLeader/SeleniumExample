using System.Collections.Generic;
using System.Data;
using AutomationExamplesForTest.Startup;
using log4net;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExamplesForTest.WebTests
{
    public class BaseWeb : BaseFramework
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseWeb));

        protected string? BrowserType { get; set; }
        protected IWebDriver? Driver { get; set; }

        public BaseWeb()
        {
        }

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeSetUp)}' called");

            base.OneTimeSetUp();

            BrowserType = InitFramework.Configuration?
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["BrowserType"].ToLower();
        }

        [OneTimeTearDown]
        public override void OneTimeTearDown()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeTearDown)}' called");

            base.OneTimeTearDown();
        }
    }
}