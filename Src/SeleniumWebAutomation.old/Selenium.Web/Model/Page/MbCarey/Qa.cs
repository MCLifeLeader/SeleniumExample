using OpenQA.Selenium;

namespace Selenium.Web.Tests.Model.Page.MbCarey
{
   public class Qa : Navigation
   {
      public static IWebElement MainPageText => Driver.FindElement(By.XPath("/html/body/div[1]/partial/main/h2"));
   }
}