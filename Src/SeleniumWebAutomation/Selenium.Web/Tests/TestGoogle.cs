using System;
using System.Data;
using System.Reflection;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Web.Extensions;
using Selenium.Web.Model.Page.Google;
using Selenium.Web.Model.Page.MbCarey;

namespace Selenium.Web.Tests
{
   [TestFixture]
   public class TestGoogle : BaseTestClass
   {
      // ReSharper disable once InconsistentNaming
      private static readonly ILog _logger = LogManager.GetLogger(typeof(TestGoogle));

      [SetUp]
      public void DerivedSetUp() { }

      [TearDown]
      public void DerivedTearDown() { }

      [Test]
      public void RunGoogleTest()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }

         WebDriverConfig.Driver.Navigate().GoToUrl(WebDriverConfig.ServiceEndPoint);
         GoogleHome.SearchForm.Set("mbcarey.com Michael Carey Technology");
         GoogleHome.SearchForm.SendKeys(Keys.Return);

         IWebElement result = GoogleSearchResults.SearchResults.FindByTextContains("Development Technologies");
         Assert.IsTrue(result.Text.Contains("Development Technologies"));

         result = GoogleSearchResults.SearchHrefResults.FindByTextContains("Technologies");
         result.Click();

         Assert.IsTrue(Technologies.MainPageText.Displayed);
         Technologies.QualityAssuranceLink.Click();

         Assert.IsTrue(Qa.MainPageText.Displayed);

         WebDriverConfig.WaitTill(new TimeSpan(0,0,0,5));
      }
   }
}
