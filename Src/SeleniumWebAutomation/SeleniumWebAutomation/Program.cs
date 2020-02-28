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
      // ReSharper disable once InconsistentNaming
      private static readonly ILog _logger = LogManager.GetLogger(typeof(Program));

      static void Main(string[] args)
      {
         Stopwatch timer = new Stopwatch();
         timer.Start();

         string l4Net = Path.Combine(Environment.CurrentDirectory, "SeleniumWebAutomation.exe.config");
         log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(l4Net));

         _logger.Info("Starting... SeleniumWebAutomation");
         _logger.Info($"Version: {Assembly.GetExecutingAssembly().GetName()}");

         //TestGoogle googleTests = new TestGoogle();
         //googleTests.BaseSetUp(Settings.Default.WebUrlGoogle);
         //googleTests.RunGoogleTest();
         //googleTests.BaseTearDown();

         TestMbCarey mbcareyTests = new TestMbCarey();
         mbcareyTests.BaseSetUp(Settings.Default.WebUrlMbCarey);
         mbcareyTests.HomePage();
         mbcareyTests.MenuNavigation();
         //mbcareyTests.ExperiencePage();
         //mbcareyTests.ProjectsPage();
         //mbcareyTests.SkillsPage();
         mbcareyTests.BaseTearDown();

         timer.Stop();
         _logger.Info($"Ending... SeleniumWebAutomation - Elapsed Time = {timer.Elapsed}");
      }
   }
}
