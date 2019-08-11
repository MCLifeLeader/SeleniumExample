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
         GoogleHome.SearchForm.Set("mbcarey.com Michael Carey Technology");
         GoogleHome.SearchForm.SendKeys(Keys.Return);

         IWebElement result = GoogleSearchResults.SearchResults.FindByTextContains("Development Technologies");
         Assert.IsTrue(result.Text.Contains("Development Technologies"));

         result = GoogleSearchResults.SearchHrefResults.FindByTextContains("Technologies");
         result.Click();

         Assert.IsTrue(MbCareyTechnologies.MainPageText.Displayed);
         MbCareyTechnologies.QualityAssuranceLink.Click();

         Assert.IsTrue(MbCareyQa.MainPageText.Displayed);

         WebDriverConfig.WaitTill(new TimeSpan(0,0,0,5));
      }
   }
}
