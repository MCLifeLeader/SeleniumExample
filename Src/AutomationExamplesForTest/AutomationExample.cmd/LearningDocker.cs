using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using log4net;

namespace AutomationExample.cmd
{
    public class LearningDocker
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(LearningDocker));
        public DockerSetup DockerSetup { get; private set; }

        public LearningDocker()
        {
            DockerSetup = new DockerSetup();
        }

        public async Task Run()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(Run)}' called");

            _logger.Debug("Starting Docker Image");

            //await DockerSetup.PullImageAsync(
            //    "kb7ppbimagestore.azurecr.io:443/automationexampleweb", 
            //    "latest");

            //string containerId = await DockerSetup.StartContainerAsync(
            //    "kb7ppbimagestore.azurecr.io:443/automationexampleweb",
            //    "latest",
            //    "49080",
            //    "80",
            //    new List<string> { $"Environment=Release" }
            //);

            await DockerSetup.PullImageAsync(
                "automationexampleweb",
                "latest");

            string containerId = await DockerSetup.StartContainerAsync(
                "automationexampleweb",
                "latest",
                "49080",
                "80",
                new List<string> { $"Environment=Release" }
            );

            _logger.Debug("Thread Sleep");
            await Task.Delay(5000);

            _logger.Debug("Stopping Docker Image");
            await DockerSetup.StopContainerAsync(containerId);
        }
    }
}
