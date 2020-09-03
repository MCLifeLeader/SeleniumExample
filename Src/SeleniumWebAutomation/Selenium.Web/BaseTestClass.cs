using System;
using System.Reflection;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using Selenium.Config;
using Selenium.Data.Repository.Interfaces;
using Selenium.Data.SeleniumDataRepository;
using Selenium.Data.SeleniumDataRepository.Models;
using Selenium.Web.Tests.Extensions;
using Selenium.Web.Tests.Model;
using Selenium.Web.Tests.Model.Enum;

namespace Selenium.Web.Tests
{
   public class BaseTestClass
   {
      // ReSharper disable once InconsistentNaming
      private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseTestClass));

      public static TimeSpan ImplicitlyWait { get; set; } = new TimeSpan(0, 0, 0, 15);
      public static TimeSpan SetPageLoadTimeout { get; set; } = new TimeSpan(0, 0, 0, 120);
      public static TimeSpan SetScriptTimeout { get; set; } = new TimeSpan(0, 0, 0, 120);

      protected IUnitOfWork DataUnitOfWork { get; set; }
      protected ConfigurationRepository DataConfigurationRepository { get; set; }

      [SetUp]
      public void BaseSetUp()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         try
         {
            // This is an example on how to connect to a database through Entity Framework with full CRUD support.
            // This example project should work with or without the database initialized.
            // In the real world you would likely rely on the database being present and that if the database was missing
            //    the test run would fail.

            DataUnitOfWork = new SeleniumDataContext();
            DataConfigurationRepository = new ConfigurationRepository(DataUnitOfWork);

            Configuration mbCareyWeb = DataConfigurationRepository.GetEntityByKey("WebUrlMbCarey");
            Configuration userContext = DataConfigurationRepository.GetEntityByKey("UserContext");

            WebDriverConfig.ServiceEndPoint = !string.IsNullOrEmpty(mbCareyWeb.Value) ? mbCareyWeb.Value : Settings.Default.WebUrlMbCarey;
            WebDriverConfig.UserContext = userContext != null ? userContext.Value.FromJson<UserContext>() : new UserContext();
         }
         catch (Exception ex)
         {
            _logger.Warn(ex.Message, ex);

            // Fall back if the database fails to init.
            WebDriverConfig.ServiceEndPoint = Settings.Default.WebUrlMbCarey;
            WebDriverConfig.UserContext = new UserContext();
         }

         TestDriverType driverType = TestDriverType.FireFox;

         switch (driverType)
         {
            case TestDriverType.Marionette:
               throw new NotImplementedException();
               break;
            case TestDriverType.FireFox:
               // Firefox Driver Stub
               WebDriverConfig.Driver = new FirefoxDriver();
               break;
            case TestDriverType.Chrome:
               // Chrome Driver Stub
               WebDriverConfig.Driver = new ChromeDriver();
               break;
            case TestDriverType.Edge:
               // Microsoft Edge Driver Stub
               WebDriverConfig.Driver = new EdgeDriver();
               break;
            case TestDriverType.InternetExplorer:
               // Microsoft IE Driver Stub
               WebDriverConfig.Driver = new InternetExplorerDriver();
               break;
         }

         WebDriverConfig.Driver.Manage().Window.Maximize();

         WebDriverConfig.Wait = new WebDriverWait(WebDriverConfig.Driver, TimeSpan.FromSeconds(0));
         WebDriverConfig.Wait5 = new WebDriverWait(WebDriverConfig.Driver, TimeSpan.FromSeconds(5));
         WebDriverConfig.Wait10 = new WebDriverWait(WebDriverConfig.Driver, TimeSpan.FromSeconds(10));
         WebDriverConfig.Wait30 = new WebDriverWait(WebDriverConfig.Driver, TimeSpan.FromSeconds(30));

         WebDriverConfig.Driver.Manage().Timeouts().ImplicitWait = ImplicitlyWait;
         WebDriverConfig.Driver.Manage().Timeouts().PageLoad = SetPageLoadTimeout;
         WebDriverConfig.Driver.Manage().Timeouts().AsynchronousJavaScript = SetScriptTimeout;
      }

      [TearDown]
      public void BaseTearDown()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         // Close out the browser session
         WebDriverConfig.Driver.Quit();
      }
   }
}
