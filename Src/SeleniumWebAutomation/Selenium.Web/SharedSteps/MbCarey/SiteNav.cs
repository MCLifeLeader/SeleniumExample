using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Web.Tests.Model.Page.MbCarey;

namespace Selenium.Web.Tests.PageEvents.MbCarey
{
   /// <summary>
   /// This method of accessing the links is faster than the "AllLinksOnPage".
   /// Even though the DOM has to be accessed to pull back the link. The link is expressly defined using XPath.
   /// Additionally, there is no need to search the collection of links for a particular link.
   /// </summary>
   public class SiteNav : WebDriverConfig
   {
      public static void GotoWorkHistoryPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopExperienceLink.Click();
         Navigation.TopWorkHistoryLink.Click();
      }

      public static void GotoAdverTranPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopAdverTranLink.Click();
      }

      public static void GotoA_GamePage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopAGameLink.Click();
      }

      public static void GotoAzureServicesPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopAzureServicesLink.Click();
      }

      public static void GotoCit261Page()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopCit261Link.Click();
      }

      public static void GotoCs313Page()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopCs313Link.Click();
      }

      public static void GotoCs364Page()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopCs364Link.Click();
      }

      public static void GotoEncompassPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopEncompassLink.Click();
      }

      public static void GotoFamilyKeyPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopFamilyKeyLink.Click();
      }

      public static void GotoMlmLinkupPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopMlmLinkupLink.Click();
      }

      public static void GotoRedheadMobilePage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopProjectsLink.Click();
         Navigation.TopRedheadMobileLink.Click();
      }

      public static void GotoTechnicalPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopSkillsLink.Click();
         Navigation.TopTechnicalLink.Click();
      }

      public static void GotoLeadershipPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopSkillsLink.Click();
         Navigation.TopLeadershipLink.Click();
      }

      public static void GotoGitPage()
      {
         Navigation.TopSiteHomeLink.Click();
         Navigation.TopGitLink.Click();
      }
   }
}
