using OpenQA.Selenium;

namespace Selenium.Web.Model.Page.MbCarey
{
   public class Navigation : WebDriverConfig
   {
      public static IWebElement TopSiteHomeLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/a"));

      public static IWebElement TopExperienceLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[1]/a"));
      public static IWebElement TopWorkHistoryLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[1]/div/a"));

      public static IWebElement TopProjectsLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/a"));
      public static IWebElement TopAdverTranLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[1]"));
      public static IWebElement TopAGameLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[2]"));
      public static IWebElement TopCit261Link => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[3]"));
      public static IWebElement TopCs313Link => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[4]"));
      public static IWebElement TopCs364Link => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[5]"));
      public static IWebElement TopEncompassLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[6]"));
      public static IWebElement TopFamilyKeyLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[7]"));
      public static IWebElement TopMlmLinkupLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[8]"));
      public static IWebElement TopRedheadMobileLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[2]/div/a[9]"));

      public static IWebElement TopSkillsLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/a"));
      public static IWebElement TopDevelopmentQaLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/div/a[1]"));
      public static IWebElement TopLeadershipLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/div/a[2]"));
      
      public static IWebElement TopGitLink => Driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/div/a"));
   }
}
