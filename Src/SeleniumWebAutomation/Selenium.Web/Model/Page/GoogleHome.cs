using OpenQA.Selenium;

namespace Selenium.Web.Model.Page
{
   public class GoogleHome : WebDriverConfig
   {
      public static IWebElement GoogleLogo => Driver.FindElement(By.Id("hplogo"));

      public static IWebElement SearchForm => Driver.FindElement(By.XPath("/html/body/div/div[3]/form/div[2]/div[1]/div[1]/div/div[2]/input"));

      public static IWebElement GoogleSearchBtn => Driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[3]/center/input[1]"));
   }
}
