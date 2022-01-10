﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Docker.DotNet;
using Docker.DotNet.Models;
using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;
using Microsoft.Extensions.Configuration;

namespace AutomationExamplesForTest.Startup
{
    /// <summary>
    /// This method of initializing a framework isn't necessarily the best. Alternately you can use injection scafolding.
    /// </summary>
    public static class InitFramework
    {
        private static bool _loggingInitComplete { get; set; }
        private static readonly ILog _logger = LogManager.GetLogger(typeof(InitFramework));
        public static IConfiguration? Configuration { get; set; }

        /// <summary>
        /// Read the appsettings.json file and keep those values in memory for later access.
        /// </summary>
        /// <exception cref="Exception"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        public static void InitConfiguration()
        {
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
            _logger.DebugFormat($"'{nameof(InitFramework)}.{nameof(InitLogger)}' called");

            // Only initialize the logging service once. Ignore later start requests.
            if (!_loggingInitComplete)
            {
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
            }
        }

        public static async Task<bool> StartWebInstance()
        {
            // Default Docker Engine
            DockerClient? client = new DockerClientConfiguration(new Uri(DockerApiUri())).CreateClient();

            IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
                new ContainersListParameters()
                {
                    All = true,
                });

            // ReSharper disable once StringLiteralTypo
            ContainerListResponse containerResponse = containers.FirstOrDefault(e => e.Image.Contains("automationexampleweb"));

            bool result = await client.Containers.StartContainerAsync(containerResponse?.ID, null);

            string portNumber = string.Empty;
            foreach (var port in containerResponse.Ports)
            {
                _logger.Debug($"IP={port.IP}");
                _logger.Debug($"PublicPort={port.PublicPort}");
                _logger.Debug($"PrivatePort={port.PrivatePort}");
                _logger.Debug($"Type={port.Type}");

                if (port.PrivatePort == 443)
                {
                    portNumber = port.PublicPort.ToString();
                }
            }

            containerResponse.Command = $"exec -i -e ASPNETCORE_HTTPS_PORT={portNumber} -w \"/app\" sh -c dotnet --additionalProbingPath \"/root/.nuget/fallbackpackages\" \"/app/bin/Debug/net6.0/AutomationExample.Web.dll\"";

            return result;
        }

        private static string DockerApiUri()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return "npipe://./pipe/docker_engine";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return "unix:/var/run/docker.sock";
            }

            throw new Exception("Was unable to determine what OS this is running on, does not appear to be Windows or Linux!?");
        }

        public static async Task<bool> StopWebInstance()
        {
            // Default Docker Engine on Windows
            DockerClient? client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();

            //ToDo: Detect OS and run alternate Image command
            // Default Docker Engine on Linux
            //DockerClient? client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();

            IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
                new ContainersListParameters()
                {
                    All = true,
                });

            // ReSharper disable once StringLiteralTypo
            ContainerListResponse? containerResponse = containers.FirstOrDefault(e => e.Image.Contains("automationexampleweb"));

            bool result = await client.Containers.StopContainerAsync(containerResponse?.ID, new ContainerStopParameters(), CancellationToken.None);

            return result;
        }
    }
}
