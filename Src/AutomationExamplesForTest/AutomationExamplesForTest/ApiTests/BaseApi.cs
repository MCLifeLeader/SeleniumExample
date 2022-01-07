using System.Collections.Generic;
using System.Data;
using AutomationExamplesForTest.Startup;
using log4net;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AutomationExamplesForTest.ApiTests
{
    public class BaseApi : BaseFramework
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseApi));

        public BaseApi()
        {
        }

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