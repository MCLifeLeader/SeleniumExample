using log4net;
using NUnit.Framework;

namespace AutomationExamplesForTest.ApiTests
{
    [TestFixture]
    public class BaseApi : BaseFramework
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseApi));

        public BaseApi()
        {
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