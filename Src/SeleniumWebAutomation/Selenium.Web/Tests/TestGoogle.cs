using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Web.Extensions;
using Selenium.Web.Model.Page;

namespace Selenium.Web.Tests
{
   [TestFixture]
   public class TestGoogle : BaseTestClass
   {
      private static readonly ILog _logger = LogManager.GetLogger(typeof(TestGoogle));

      [SetUp]
      public void DerivedSetUp() { }

      [TearDown]
      public void DerivedTearDown() { }

      [Test]
      public void RunGoogleTest()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         WebDriverConfig.Driver.Navigate().GoToUrl(WebDriverConfig.ServiceEndPoint);
         GoogleHome.SearchForm.Set("world of warcraft");
         GoogleHome.SearchForm.SendKeys(Keys.Return);

         IWebElement results = GoogleSearchResults.SearchResults.FindByTextContains("Wikipedia");

         Assert.IsTrue(results.Text.Contains("Wikipedia"));

         GoogleSearchResults.SearchForm.Set("Blizzard");
         GoogleSearchResults.SearchFormBtn.Click();

         results = GoogleSearchResults.SearchResults.FindByTextContains("Blizzard Entertainment");
         Assert.IsTrue(results.Text.Contains("Entertainment"));
      }
   }
}
