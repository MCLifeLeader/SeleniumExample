using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using AutomationExamplesForTest.Startup;
using log4net;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace AutomationExamplesForTest
{
    /// <summary>
    /// This is intended to test web or restful apis.
    /// </summary>
    [TestFixture]
    public class BaseFramework
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseFramework));

        public static Dictionary<string,string> ConnectionStrings { get; set; }
        /// <summary>
        /// This value could be stored in a common shared configuration quick access class
        /// </summary>
        public string BaseRoute { get; set; }
        /// <summary>
        /// This value could be stored in a common shared configuration quick access class
        /// </summary>
        public string BaseUrl { get; set; }

        public BaseFramework()
        {
            InitFramework.InitLogger();
            InitFramework.InitConfiguration();

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
                if (dbConnectionStr.Key != "ConnectionStrings")
                {
                    // Removing the first part keyword "ConnectionStrings"
                    ConnectionStrings.Add(dbConnectionStr.Key.Split(":")[1], dbConnectionStr.Value);
                }
            }
        }


        #region Base Test Framework startup and teardown methods

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeSetUp)}' called");
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(OneTimeTearDown)}' called");
        }

        [SetUp]
        public virtual void SetUp()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(SetUp)}' called");
        }

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
