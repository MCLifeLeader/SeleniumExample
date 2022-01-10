using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace AutomationExample.cmd
{
    public class DockerSetup
    {
        private readonly DockerClient _dockerClient;

        public DockerSetup()
        {
            _dockerClient = new DockerClientConfiguration(new Uri(DockerApiUri())).CreateClient();
        }

        private static string DockerApiUri()
        {
            var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            if (isWindows)
            {
                return "npipe://./pipe/docker_engine";
            }

            var isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            var isMacOs = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            if (isLinux || isMacOs)
            {
                return "unix:/var/run/docker.sock";
            }

            throw new Exception(
                "Was unable to determine what OS this is running on, does not appear to be Windows, MacOS or Linux!?");
        }

        public async Task PullImageAsync(string image, string tag)
        {
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

        public async Task<string> StartContainerAsync(string image, 
            string tag, 
            string hostPort, 
            string containerPort,
            IList<string> environmentVariables)
        {
            var response = await _dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters
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

        public async Task StopContainerAsync(string? containerId)
        {
            if (containerId != null)
            {
                await _dockerClient.Containers.KillContainerAsync(containerId, new ContainerKillParameters());
            }
        }
    }
}
