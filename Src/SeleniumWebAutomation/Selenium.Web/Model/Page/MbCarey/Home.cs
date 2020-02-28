using OpenQA.Selenium;

namespace Selenium.Web.Model.Page.MbCarey
{
   public class Home : Navigation
   {
      public static IWebElement AboutMeTextDivSection => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[1]"));
      public static IWebElement ResumeLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[2]/p[2]/a"));
      public static IWebElement ProjectLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[3]/p[2]/a"));
      public static IWebElement SkillsLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[4]/p[2]/a"));
      public static IWebElement ExperienceLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[5]/p[2]/a"));
      public static IWebElement LinkedInLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[6]/a[1]"));
      public static IWebElement FacebookLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[6]/a[2]"));
      public static IWebElement YouTubeLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[6]/a[3]"));
      public static IWebElement InstagramLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[6]/a[4]"));
      public static IWebElement TwitterLink => Driver.FindElement(By.XPath("/html/body/div/partial/main/div[2]/div[6]/a[5]"));
   }
}