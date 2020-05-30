using System;
using System.Data;
using System.Reflection;
using log4net;
using NUnit.Framework;
using Selenium.Web.Tests.Extensions;
using Selenium.Web.Tests.Model.Page.MbCarey;

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
      public void MenuNavigationByExactElement()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

         DerivedSetUp();

         #region Explicit link refs Example

         // This method of accessing the links is faster than the "AllLinksOnPage".
         // Even though the DOM has to be accessed to pull back the link. The link is expressly defined using XPath.
         // Additionally, there is no need to search the collection of links for a particular link.

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
         #endregion

     }

      [Test]
      public void MenuNavigationByElementCollection()
      {
         _logger.DebugFormat($"'{GetType().Name}.{MethodBase.GetCurrentMethod().Name}' called");

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
