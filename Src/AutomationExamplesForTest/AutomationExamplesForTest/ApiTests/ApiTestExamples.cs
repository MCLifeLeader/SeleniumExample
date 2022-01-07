using log4net;
using NUnit.Framework;

namespace AutomationExamplesForTest.ApiTests
{
    /// <summary>
    /// This represents a series of API based tests
    /// </summary>
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ApiTestExamples : BaseApi
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ApiTestExamples));

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}