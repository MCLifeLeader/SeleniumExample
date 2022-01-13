using AutomationExample.Tests.Startup;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationExample.Tests.Web
{
    /// <summary>
    ///     Setting up some basic testing framework to make it easier to write tests.
    /// </summary>
    public class BaseWeb : BaseFramework
    {
        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseWeb));
        protected WebDriverFactory DriverFactory { get; set; }
        protected IWebDriver Driver { get; set; }

        /// <summary>
        ///     Used to setup session test state. This will typically only be run once per test fixture.
        /// </summary>
        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeSetUp)}' called");

            base.OneTimeSetUp();

            DriverFactory = new WebDriverFactory(InitFramework.Configuration);

            Driver = DriverFactory.Initialize();
        }

        /// <summary>
        ///     Used to tear down session test state. This will typically only be run once per test fixture.
        /// </summary>
        [OneTimeTearDown]
        public override void OneTimeTearDown()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeTearDown)}' called");

            Driver.Close();
            Driver.Dispose();

            base.OneTimeTearDown();
        }
    }
}