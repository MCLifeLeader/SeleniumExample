using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Configuration;

namespace AutomationExample.Tests.Startup
{
    /// <summary>
    ///     This method of initializing a framework isn't necessarily the best. Alternately you can use injection scaffolding.
    /// </summary>
    public static class InitFramework
    {
        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(InitFramework));

        // Prevent double execution of the log4net code
        private static bool _loggingInitComplete { get; set; }

        /// <summary>
        ///     Represents the data found within appsettings.json
        /// </summary>
        public static IConfiguration? Configuration { get; private set; }

        /// <summary>
        ///     Read the appsettings.json file and keep those values in memory for later access.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static void InitConfiguration()
        {
            _logger.DebugFormat($"'{nameof(InitFramework)}.{nameof(InitConfiguration)}' called");

            string? dir = Path.GetDirectoryName(typeof(InitFramework).Assembly.Location);
            if (dir != null)
            {
                Environment.CurrentDirectory = dir;
                Directory.SetCurrentDirectory(dir);
            }
            else
            {
                throw new Exception(
                    "Path.GetDirectoryName(typeof(TestingWithReferencedFiles).Assembly.Location) returned null");
            }

            if (File.Exists($"{Path.Combine(dir, "appsettings.json")}"))
                Console.WriteLine("Found appsettings file");
            else
                throw new FileNotFoundException("Unable to locate the appsettings.json configuration file.");

            // Read the appsettings.json + environment settings file.
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            Configuration = builder.Build();
        }

        /// <summary>
        ///     Initialize the log4net logging service.
        ///     Direct init of logging service available if the rest of the service QaFramework is not needed but logging is.
        ///     Include the log4net configuration file at the same level as the executing assembly. Do **not** provide a fully
        ///     qualified path.
        /// </summary>
        /// <param name="log4NetConfigFileName">
        ///     log4net.config file should be at the same level as the application or DLLs. Only
        ///     provide the config filename.
        /// </param>
        public static void InitLogger(string log4NetConfigFileName = "log4net.config")
        {
            // Only initialize the logging service once. Ignore later start requests.
            if (!_loggingInitComplete)
                try
                {
                    // Set the current working directory to the same location as the executing / runtime application.
                    string? dir = Path.GetDirectoryName(typeof(InitFramework).Assembly.Location);
                    if (dir != null)
                    {
                        Environment.CurrentDirectory = dir;
                        Directory.SetCurrentDirectory(dir);
                    }
                    else
                    {
                        throw new Exception(
                            "Path.GetDirectoryName(typeof(TestingWithReferencedFiles).Assembly.Location) returned null");
                    }

                    XmlDocument log4NetConfig = new XmlDocument();

                    // Open log4net configuration file and load settings into the log4net in memory configuration
                    log4NetConfig.Load(File.OpenRead(Path.Combine(Environment.CurrentDirectory, log4NetConfigFileName)));
                    ILoggerRepository repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(Hierarchy));
                    XmlConfigurator.Configure(repo, log4NetConfig["log4net"]);

                    _loggingInitComplete = true;
                }
                catch (Exception ex)
                {
                    // Provide a warning. This is not a critical failure as testing can continue. No logging to disk will occur.
                    Console.WriteLine($"WARNING: Unable to locate and initialize log4net.config - {ex.Message}");
                }

            _logger.DebugFormat($"'{nameof(InitFramework)}.{nameof(InitLogger)}' called");
        }
    }
}