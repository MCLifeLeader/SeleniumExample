using log4net;
using NUnit.Framework;

namespace AutomationExample.Tests.Api
{
    public class BaseApi : BaseFramework
    {
        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseApi));

        [OneTimeSetUp]
        public override void OneTimeSetUp()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeSetUp)}' called");

            base.OneTimeSetUp();
        }

        [OneTimeTearDown]
        public override void OneTimeTearDown()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeTearDown)}' called");

            base.OneTimeTearDown();
        }
    }
}