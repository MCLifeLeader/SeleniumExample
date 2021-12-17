using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using log4net;
using Ninject;
using Selenium.Web.Automation.Properties;
using Selenium.Web.Tests.Services;
using Selenium.Web.Tests.Tests.MbCarey;

namespace Selenium.Web.Automation
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

         using (IKernel kernel = NinjectCommon.CreateKernel())
         {
            TestMbCarey mbcareyTests = new TestMbCarey();
            mbcareyTests.BaseSetUp();
            mbcareyTests.HomePage();
            mbcareyTests.NavigatePages();
            mbcareyTests.MenuNavigationByElementCollection();
            mbcareyTests.LeadershipPage();
            //mbcareyTests.ExperiencePage();
            //mbcareyTests.ProjectsPage();
            //mbcareyTests.SkillsPage();
            mbcareyTests.BaseTearDown();
         }

         timer.Stop();
         _logger.Info($"Ending... SeleniumWebAutomation - Elapsed Time = {timer.Elapsed}");
      }
   }
}
