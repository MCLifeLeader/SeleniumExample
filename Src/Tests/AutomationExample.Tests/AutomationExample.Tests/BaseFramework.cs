using System.Collections.Generic;
using System.Data;
using System.IO;
using AutomationExample.Tests.Startup;
using log4net;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AutomationExample.Tests
{
    /// <summary>
    /// This is intended to test web or restful apis.
    /// </summary>
    public class BaseFramework
    {
        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseFramework));

        /// <summary>
        /// A Collection of various database connection strings
        /// </summary>
        public static Dictionary<string, string> ConnectionStrings { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// This value could be stored in a common shared configuration quick access class
        /// </summary>
        public string BaseRoute { get; set; } = string.Empty;

        /// <summary>
        /// This value could be stored in a common shared configuration quick access class
        /// </summary>
        public string BaseUrl { get; set; } = string.Empty;

        public BaseFramework()
        {
        }

        #region Base Test Framework startup and teardown methods

        /// <summary>
        /// Used to setup session test state. This will typically only be run once per test fixture.
        /// </summary>
        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            InitFramework.InitLogger();
            InitFramework.InitConfiguration();

            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeSetUp)}' called");

            if (InitFramework.Configuration == null)
            {
                throw new NoNullAllowedException($"{nameof(InitFramework.Configuration)} cannot be null");
            }

            BaseUrl = InitFramework.Configuration.GetSection("AppSettings")["BaseUrl"];
            BaseRoute = InitFramework.Configuration.GetSection("AppSettings")["BaseRoute"];

            IEnumerable<KeyValuePair<string, string>> rawStringsList = InitFramework
                .Configuration
                .GetSection("ConnectionStrings").AsEnumerable();

            foreach (KeyValuePair<string, string> dbConnectionStr in rawStringsList)
            {
                if (dbConnectionStr.Key != "ConnectionStrings" && !ConnectionStrings.ContainsKey(dbConnectionStr.Key.Split(":")[1]))
                {
                    // Removing the first part keyword "ConnectionStrings"
                    ConnectionStrings.Add(dbConnectionStr.Key.Split(":")[1], dbConnectionStr.Value);
                }
            }
        }

        /// <summary>
        /// Used to tear down session test state. This will typically only be run once per test fixture.
        /// </summary>
        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeTearDown)}' called");
        }

        /// <summary>
        /// Used to setup a test state for each test. This will run in between every test executed.
        /// </summary>
        [SetUp]
        public virtual void SetUp()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(SetUp)}' called");
        }

        /// <summary>
        /// Used to tear down test state for each test. This will run in between every test executed.
        /// </summary>
        [TearDown]
        public virtual void TearDown()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(TearDown)}' called");
        }

        public virtual string BaseRouteCombine(params string[] paths)
        {
            List<string> basePath = new List<string> { BaseRoute };
            basePath.AddRange(paths);

            return Path.Combine(basePath.ToArray()).Replace('\\', '/');
        }
        #endregion
    }
}
