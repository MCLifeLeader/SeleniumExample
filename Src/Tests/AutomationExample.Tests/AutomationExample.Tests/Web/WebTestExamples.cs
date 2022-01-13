using System;
using AutomationExample.Tests.Web.PageModels;
using log4net;
using NUnit.Framework;

namespace AutomationExample.Tests.Web
{
    /// <summary>
    ///     This represents a series of selenium based tests.
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Default)]
    [Category("Selenium")]
    public class WebTestExamples : BaseWeb
    {
        /// <summary>
        ///     This is provided for an example. Use this to setup test state for each test executed.
        /// </summary>
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
        }

        /// <summary>
        ///     This is provided for an example. Use this to tear down test state or reset test state after each test.
        /// </summary>
        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
        }

        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(WebTestExamples));

        /// <summary>
        ///     Example test using Selenium
        /// </summary>
        /// <param name="arguments">Test data arguments</param>
        // Individual test case attribute and parallel threading behavior defined.
        [Test]
        [Order(1)]
        [Parallelizable(ParallelScope.Default)]
        [Category("SeleniumTests")]
        // Inject data directly into the test case.
        // You can add additional parameters / test data.
        [TestCase("WorkItem", "000001", Category = "SeleniumDev")]
        [TestCase("WorkItem", "000002", Category = "SeleniumTest")]
        public void NavigatePages(params object[] arguments)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(NavigatePages)}' called");

            // This is an example of how to inject data into the test based on the Category of test.
            _logger.Info($"Test Case Id: {arguments[1]}");

            Home home = new Home(Driver);
            home.NavigateTo();
            home.WaitTill(TimeSpan.FromSeconds(1));

            Counter counter = home.ClickCounterAndNavigate();
            FetchData fetchData = counter.ClickFetchDataAndNavigate();

            home = fetchData.ClickHomeAndNavigate();

            Assert.NotNull(home.HomeParagraphElement.Text);
        }

        /// <summary>
        ///     Example test using Selenium
        /// </summary>
        /// <param name="arguments">Test data arguments</param>
        // Individual test case attribute and parallel threading behavior defined.
        [Test]
        [Order(2)]
        [Parallelizable(ParallelScope.Default)]
        [Category("SeleniumTests")]
        [TestCase("WorkItem", "000003", Category = "Example")]
        public void ClickCounterButton(params object[] arguments)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(NavigatePages)}' called");

            // This is an example of how to inject data into the test based on the Category of test.
            _logger.Info($"Test Case Id: {arguments[1]}");

            Counter counter = new Counter(Driver);
            counter.NavigateTo();

            counter.WaitTill(TimeSpan.FromSeconds(2));

            counter.ClickCounterButton();
            counter.ClickCounterButton();
            counter.ClickCounterButton();
            counter.ClickCounterButton();

            counter.WaitTill(TimeSpan.FromSeconds(2));

            Assert.True(counter.CounterParagraphElement.Text.Contains("4"));
        }
    }
}