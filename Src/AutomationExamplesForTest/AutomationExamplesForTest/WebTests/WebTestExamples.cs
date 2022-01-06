using NUnit.Framework;

namespace AutomationExamplesForTest.WebTests
{
    /// <summary>
    /// This represents a series of selenium based tests.
    /// </summary>
    [TestFixture, Parallelizable(ParallelScope.Default)]
    public class WebTestExamples : BaseWeb
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}