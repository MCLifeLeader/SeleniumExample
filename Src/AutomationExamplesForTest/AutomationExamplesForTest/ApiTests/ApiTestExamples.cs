using NUnit.Framework;

namespace AutomationExamplesForTest.ApiTests
{
    /// <summary>
    /// This represents a series of API based tests
    /// </summary>
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ApiTestExamples : BaseApi
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}