using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using NUnit.Framework;
using Selenium.Web.Model.Page.MbCarey;

namespace Selenium.Web.Tests
{
   [TestFixture]
   public class TestMbCarey : BaseTestClass
   {
      // ReSharper disable once InconsistentNaming
      private static readonly ILog _logger = LogManager.GetLogger(typeof(TestMbCarey));

      [SetUp]
      public void DerivedSetUp() { }

      [TearDown]
      public void DerivedTearDown() { }

      [Test]
      public void HomePage()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }

         WebDriverConfig.Driver.Navigate().GoToUrl(WebDriverConfig.ServiceEndPoint);

         Home.ResumeLink.Click();
         WebDriverConfig.CloseWindowByUrlOrHandle(WebDriverConfig.Driver.CurrentWindowHandle, "Computer programmer", TimeSpan.FromSeconds(5));
         Navigation.TopSiteHomeLink.Click();

         Home.ProjectLink.Click();
         Navigation.TopSiteHomeLink.Click();

         Home.SkillsLink.Click();
         Navigation.TopSiteHomeLink.Click();
         
         Home.ExperienceLink.Click();
         Navigation.TopSiteHomeLink.Click();
         
         Home.LinkedInLink.Click();
         WebDriverConfig.CloseWindowByUrlOrHandle(WebDriverConfig.Driver.CurrentWindowHandle, "LinkedIn", TimeSpan.FromSeconds(5));
         Navigation.TopSiteHomeLink.Click();

         Home.FacebookLink.Click();
         WebDriverConfig.CloseWindowByUrlOrHandle(WebDriverConfig.Driver.CurrentWindowHandle, "Facebook", TimeSpan.FromSeconds(5));
         Navigation.TopSiteHomeLink.Click();

         Home.YouTubeLink.Click();
         WebDriverConfig.CloseWindowByUrlOrHandle(WebDriverConfig.Driver.CurrentWindowHandle, "YouTube", TimeSpan.FromSeconds(5));
         Navigation.TopSiteHomeLink.Click();

         Home.InstagramLink.Click();
         WebDriverConfig.CloseWindowByUrlOrHandle(WebDriverConfig.Driver.CurrentWindowHandle, "Instagram", TimeSpan.FromSeconds(5));
         Navigation.TopSiteHomeLink.Click();

         Home.TwitterLink.Click();
         WebDriverConfig.CloseWindowByUrlOrHandle(WebDriverConfig.Driver.CurrentWindowHandle, "Twitter", TimeSpan.FromSeconds(5));
         Navigation.TopSiteHomeLink.Click();
      }

      [Test]
      public void MenuNavigation()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }

         WebDriverConfig.Driver.Navigate().GoToUrl(WebDriverConfig.ServiceEndPoint);

         Navigation.TopSiteHomeLink.Click();
         
         Navigation.TopExperienceLink.Click();
         Navigation.TopWorkHistoryLink.Click();

         Navigation.TopProjectsLink.Click();
         Navigation.TopAdverTranLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopAGameLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopCit261Link.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopCs313Link.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopCs364Link.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopEncompassLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopFamilyKeyLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopMlmLinkupLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopRedheadMobileLink.Click();

         Navigation.TopSkillsLink.Click();
         Navigation.TopDevelopmentQaLink.Click();
         Navigation.TopSkillsLink.Click();
         Navigation.TopLeadershipLink.Click();

         Navigation.TopGitLink.Click();
      }

      [Test]
      public void ExperiencePage()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }
      }

      [Test]
      public void ProjectsPage()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }
      }

      [Test]
      public void SkillsPage()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }
      }
   }
}
