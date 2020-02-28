using System;
using System.Reflection;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using Selenium.Web.Model;
using Selenium.Web.Model.Enum;

namespace Selenium.Web
{
   public class BaseTestClass
   {
      // ReSharper disable once InconsistentNaming
      private static readonly ILog _logger = LogManager.GetLogger(typeof(BaseTestClass));

      public static TimeSpan ImplicitlyWait { get; set; } = new TimeSpan(0, 0, 0, 15);
      public static TimeSpan SetPageLoadTimeout { get; set; } = new TimeSpan(0, 0, 0, 120);
      public static TimeSpan SetScriptTimeout { get; set; } = new TimeSpan(0, 0, 0, 120);

      [SetUp]
      public void BaseSetUp(string serviceEndPoint, UserContext userContext = null)
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         WebDriverConfig.ServiceEndPoint = serviceEndPoint;
         WebDriverConfig.UserContext = userContext;

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
