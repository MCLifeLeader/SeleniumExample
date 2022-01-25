using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;
using log4net;

namespace AutomationExample.Tests.Startup
{
    /// <summary>
    /// Provide automation code a method for creating and launching docker containers.
    /// </summary>
    public class DockerSupport
    {
        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(DockerSupport));

        // Docker client
        private readonly DockerClient _dockerClient;

        public DockerSupport()
        {
            _dockerClient = new DockerClientConfiguration(new Uri(DockerApiUri())).CreateClient();
        }

        #region Public Methods
        /// <summary>
        /// Pull a docker image from its repository
        /// </summary>
        /// <param name="image"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task PullImageAsync(string image, string tag)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(PullImageAsync)}' called");

            await _dockerClient.Images
                .CreateImageAsync(
                    new ImagesCreateParameters
                    {
                        FromImage = image,
                        Tag = tag
                    },
                    null,
                    new Progress<JSONMessage>());
        }

        /// <summary>
        /// Create and start a docker container from a docker image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="tag"></param>
        /// <param name="hostPort"></param>
        /// <param name="containerPort"></param>
        /// <param name="environmentVariables"></param>
        /// <returns></returns>
        public async Task<string> StartContainerAsync(string image, 
            string tag, 
            string hostPort, 
            string containerPort,
            IList<string> environmentVariables)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(StartContainerAsync)}' called");

            CreateContainerResponse? response = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
            {
                Image = $"{image}:{tag}",
                ExposedPorts = new Dictionary<string, EmptyStruct>
                {
                    {
                        containerPort, default(EmptyStruct)
                    }
                },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {containerPort, new List<PortBinding> {new PortBinding {HostPort = hostPort}}}
                    },
                    PublishAllPorts = false
                },
                Env = environmentVariables
            });

            await _dockerClient.Containers.StartContainerAsync(response.ID, null);

            return response.ID;
        }

        /// <summary>
        /// Stop a running docker container
        /// </summary>
        /// <param name="containerId"></param>
        /// <returns></returns>
        public async Task StopContainerAsync(string? containerId)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(StopContainerAsync)}' called");

            if (containerId != null)
            {
                await _dockerClient.Containers.KillContainerAsync(containerId, new ContainerKillParameters());
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Look up the running operating system the code is executing on
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private string DockerApiUri()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(DockerApiUri)}' called");

            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                return "npipe://./pipe/docker_engine";
            }

            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            bool isMacOs = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            if (isLinux || isMacOs)
            {
                return "unix:/var/run/docker.sock";
            }

            throw new Exception(
                "Was unable to determine what OS this is running on, does not appear to be Windows, MacOS or Linux!?");
        }
        #endregion
    }
}
