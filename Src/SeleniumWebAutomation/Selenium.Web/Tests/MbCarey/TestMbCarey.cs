using System;
using System.Data;
using System.Reflection;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.Web.Tests.Extensions;
using Selenium.Web.Tests.Model.Page.MbCarey;
using Selenium.Web.Tests.PageEvents.MbCarey;

namespace Selenium.Web.Tests.Tests.MbCarey
{
   [TestFixture]
   public class TestMbCarey : BaseTestClass
   {
      // ReSharper disable once InconsistentNaming
      private static readonly ILog _logger = LogManager.GetLogger(typeof(TestMbCarey));

      [SetUp]
      public void DerivedSetUp()
      {
         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }

         WebDriverConfig.Driver.Navigate().GoToUrl(WebDriverConfig.ServiceEndPoint);
      }

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

         DerivedSetUp();

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
      public void NavigatePages()
      {
         SiteNav.GotoLeadershipPage();
         SiteNav.GotoA_GamePage();
         SiteNav.GotoAdverTranPage();
         SiteNav.GotoAzureServicesPage();
         SiteNav.GotoCit261Page();
         SiteNav.GotoCs313Page();
         SiteNav.GotoCs364Page();
         SiteNav.GotoEncompassPage();
         SiteNav.GotoFamilyKeyPage();
         SiteNav.GotoGitPage();
         SiteNav.GotoMlmLinkupPage();
         SiteNav.GotoRedheadMobilePage();
         SiteNav.GotoTechnicalPage();
         SiteNav.GotoWorkHistoryPage();
      }

      [Test]
      public void MenuNavigationByElementCollection()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }

         DerivedSetUp();

         #region Link by Collection

         // Please note that the "AllLinksOnPage" collection will have more than just the menu navigation in its collection set.
         // Using the "Collection" model of pulling back elements runs ever so slightly slower than the directly linked collection.
         // This is due to the collection first needing to be loaded each time from the DOM and then searched through to find the desired Element.
         // Personal preference (mine), I like the direct XPath model as it more accurately describes the page model essentially a
         // 1:1 mapping for links to clickable events if they are static links. If the links are dynamically changing then the 
         // collection of links method is preferred.

         Navigation.AllLinksOnPage.FindByText("Experience").Click();
         Navigation.AllLinksOnPage.FindByText("Work History").Click();

         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("AdverTran").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("A Game").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("CIT 261").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("CS 313").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("CS 364").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("Encompass").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("Family Key").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("MLMLinkup").Click();
         Navigation.AllLinksOnPage.FindByText("Projects").Click();
         Navigation.AllLinksOnPage.FindByText("Redhead Mobile").Click();

         Navigation.AllLinksOnPage.FindByText("Skills").Click();
         Navigation.AllLinksOnPage.FindByText("Technical").Click();
         Navigation.AllLinksOnPage.FindByText("Skills").Click();
         Navigation.AllLinksOnPage.FindByText("Leadership").Click();

         Navigation.AllLinksOnPage.FindByText("Git").Click();
         #endregion
      }

      [Test]
      public void LeadershipPage()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
         {
            throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
         }

         DerivedSetUp();

         SiteNav.GotoLeadershipPage();

         IWebElement element = Leadership.H2Elements.FindByText("Leadership");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("DevOps Manager");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("Quality Assurance Lead / Manager");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("Scrum Master");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("Development Lead / Manager");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("Two Year Service Mission");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("Personality and Leadership Profile");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("Seminars, Trainings, Audios");
         Assert.IsNotNull(element);

         element = Leadership.H3Elements.FindByText("My Book List");
         Assert.IsNotNull(element);

      }

      //[Test]
      //public void ExperiencePage()
      //{
      //   _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

      //   if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
      //   {
      //      throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
      //   }
      //}

      //[Test]
      //public void ProjectsPage()
      //{
      //   _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

      //   if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
      //   {
      //      throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
      //   }
      //}

      //[Test]
      //public void SkillsPage()
      //{
      //   _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

      //   if (string.IsNullOrEmpty(WebDriverConfig.ServiceEndPoint))
      //   {
      //      throw new NoNullAllowedException($"{nameof(WebDriverConfig.ServiceEndPoint)} cannot be null.");
      //   }
      //}
   }
}
