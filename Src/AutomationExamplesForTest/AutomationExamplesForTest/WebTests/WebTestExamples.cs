using AutomationExamplesForTest.ApiTests;
using log4net;
using NUnit.Framework;

namespace AutomationExamplesForTest.WebTests
{
    /// <summary>
    /// This represents a series of selenium based tests.
    /// </summary>
    [TestFixture, Parallelizable(ParallelScope.Default)]
    public class WebTestExamples : BaseWeb
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(WebTestExamples));

        [Test]
        public void Test1()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(Test1)}' called");

            Assert.Pass();
        }
    }
}