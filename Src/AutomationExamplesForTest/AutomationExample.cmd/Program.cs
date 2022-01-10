// See https://aka.ms/new-console-template for more information

using System.Reflection;
using AutomationExample.cmd;
using System.Xml;
using log4net;
using log4net.Config;
using log4net.Repository;
using log4net.Repository.Hierarchy;

try
{
    // Set the current working directory to the same location as the executing / runtime application.
    string? dir = Path.GetDirectoryName(typeof(Program).Assembly.Location);
    if (dir != null)
    {
        Environment.CurrentDirectory = dir;
        Directory.SetCurrentDirectory(dir);
    }
    else
    {
        throw new Exception("Path.GetDirectoryName(typeof(TestingWithReferencedFiles).Assembly.Location) returned null");
    }

    XmlDocument log4NetConfig = new XmlDocument();

    // Open log4net configuration file and load settings into the log4net in memory configuration
    log4NetConfig.Load(File.OpenRead(Path.Combine(Environment.CurrentDirectory, "log4net.config")));
    ILoggerRepository repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(Hierarchy));
    XmlConfigurator.Configure(repo, log4NetConfig["log4net"]);

}
catch (Exception ex)
{
    // Provide a warning. This is not a critical failure as testing can continue. No logging to disk will occur.
    Console.WriteLine($"WARNING: Unable to locate and initialize log4net.config - {ex.Message}");
}

Console.WriteLine("Starting");

LearningDocker ld = new LearningDocker();
try
{
    ld.Run().GetAwaiter().GetResult();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine("Completed");
