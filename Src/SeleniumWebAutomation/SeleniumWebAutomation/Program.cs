using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using log4net;
using Selenium.Config;
using Selenium.Web.Tests;

namespace SeleniumWebAutomation
{
   class Program
   {
      private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

      static void Main(string[] args)
      {
         Stopwatch timer = new Stopwatch();
         timer.Start();

         string l4Net = Path.Combine(Environment.CurrentDirectory, "SeleniumWebAutomation.exe.config");
         log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(l4Net));

         _logger.Info("Starting... SeleniumWebAutomation");
         _logger.Info($"Version: {Assembly.GetExecutingAssembly().GetName()}");

         TestGoogle testExample = new TestGoogle();
         testExample.BaseSetUp(Settings.Default.WebUrlGoogle);
         testExample.RunGoogleTest();
         testExample.BaseTearDown();

         timer.Stop();
         _logger.Info($"Ending... SeleniumWebAutomation - Elapsed Time = {timer.Elapsed}");
      }
   }
}
