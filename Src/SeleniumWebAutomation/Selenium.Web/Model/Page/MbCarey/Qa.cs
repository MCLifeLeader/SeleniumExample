using OpenQA.Selenium;

namespace Selenium.Web.Model.Page.MbCarey
{
   public class MbCareyQa : WebDriverConfig
   {
      public static IWebElement MainPageText => Driver.FindElement(By.XPath("/html/body/div[1]/partial/main/h2"));
   }
}