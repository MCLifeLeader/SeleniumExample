using System;
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

        public async Task Run()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(Run)}' called");

            _logger.Debug("Starting Docker Image");
            await StartWebInstance();

            _logger.Debug("Thread Sleep");
            await Task.Delay(1000);

            //_logger.Debug("Stopping Docker Image");
            //await StopWebInstance();
        }

        public async Task<bool> StartWebInstance()
        {
            string imageName = "automationexampleweb";
            string containerName = "AutomationExample.Web";
            CreateContainerResponse? createContainerResponse = null;

            // Default Docker Engine
            DockerClient? client = new DockerClientConfiguration(new Uri(DockerApiUri())).CreateClient();

            IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
                new ContainersListParameters()
                {
                    All = true,
                });

            ContainerListResponse containerResponse = null;
            foreach (var container in containers)
            {
                if (container.Names.Any(e => e.Contains(containerName)))
                {
                    containerResponse = container;
                }
            }

            if (containerResponse == null)
            {

                var images = await client.Images.ListImagesAsync(new ImagesListParameters()
                {
                    All = true,
                });

                ImagesListResponse? foundImage = null;
                foreach (ImagesListResponse? image in images)
                {
                    if (image.RepoTags.Any(tag => tag.Contains(imageName)))
                    {
                        foundImage = image;
                    }

                    if (foundImage != null)
                    {
                        break;
                    }
                }

                CreateContainerParameters createContainerParameters = new CreateContainerParameters
                {
                    Image = foundImage.ID,
                    Name = containerName,
                    AttachStderr = true,
                    AttachStdout = true,
                    WorkingDir = "/app",
                    //Cmd = new List<string>()
                    //{
                    //    "",
                    //    ""
                    //},
                    //Entrypoint = new List<string>()
                    //{
                    //    "dotnet",
                    //    "AutomationExample.Web.dll"
                    //},
                    Env = new List<string>() { "Development" },
                    ExposedPorts = new Dictionary<string, EmptyStruct>()
                    {
                        {
                            "8000", default(EmptyStruct)
                        }
                    },
                    HostConfig = new HostConfig
                    {
                        PortBindings = new Dictionary<string, IList<PortBinding>>
                        {
                            {"8000", new List<PortBinding> {new PortBinding {HostPort = "8000"}}}
                        },
                        PublishAllPorts = true
                    }
                };

                createContainerResponse =
                   await client.Containers.CreateContainerAsync(createContainerParameters, default);
            }

            containers = await client.Containers.ListContainersAsync(
                new ContainersListParameters()
                {
                    All = true,
                });

            // ReSharper disable once StringLiteralTypo
            foreach (var container in containers)
            {
                if (container.Names.Any(e => e.Contains(containerName)))
                {
                    containerResponse = container;
                }
            }

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

            //containerResponse.Command = $"exec -i -e ASPNETCORE_HTTPS_PORT={portNumber} -w \"/app\" sh -c dotnet --additionalProbingPath \"/root/.nuget/fallbackpackages\" \"/app/bin/Debug/net6.0/AutomationExample.Web.dll\"";

            return result;
        }

        private string DockerApiUri()
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

        //public async Task<bool> StopWebInstance()
        //{
        //    // Default Docker Engine on Windows
        //    DockerClient? client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();

        //    //ToDo: Detect OS and run alternate Image command
        //    // Default Docker Engine on Linux
        //    //DockerClient? client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();

        //    IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(
        //        new ContainersListParameters()
        //        {
        //            All = true,
        //        });

        //    // ReSharper disable once StringLiteralTypo
        //    ContainerListResponse? containerResponse = containers.FirstOrDefault(e => e.Image.Contains("automationexampleweb"));

        //    bool result = await client.Containers.StopContainerAsync(containerResponse?.ID, new ContainerStopParameters(), CancellationToken.None);

        //    return result;
        //}
    }
}
