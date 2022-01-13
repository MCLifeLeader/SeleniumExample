# DSO Automation Project

This project repository is to store example and other developer related artifacts to help document the automation and testing of various products. This automation project will provide an example on running C# NUnit tests that will execute a simple HTTP RESTful call and will then execute a Selenium UI automation process.

## Dependencies

* Visual Studio 2022 or Visual Studio Code
* C# .NET 6 Runtime and SDK
  * Nuget Packages
* Docker Engine or Daemon installed and running
  * If on Windows use Linux support (WSL)
  * I use Docker Desktop and recommend it as it provides a GUI interface to running the containers and container management.
* The AutomationExample.Tests project needs both the AutomationExample.WebApi and AutomationExample.WebApp projects to successfully run the examples.

## Build and Run Projects

These instructions will be for running on a local developer machine after cloning the project.

1. Run the following to build the C#.Net project and create the Docker images.</br>
./build_docker.ps1

2. Run the following to create the Docker containers and run them from the Docker images.</br>
./start_docker.ps1

3. Run the following to execute the tests.</br>
./run_tests.ps1

4. Run the following to stop and remove the Docker containers. Note: The Docker images will be left and this will only stop and remove the active containers.</br>
./stop_docker.ps1
