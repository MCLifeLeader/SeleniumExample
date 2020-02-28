using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Selenium.Web.Model.Page.Google
{
   public class GoogleSearchResults : WebDriverConfig
   {
      public static IWebElement SearchForm => Driver.FindElement(By.XPath("/html/body/div[3]/form/div[2]/div[1]/div[2]/div/div[2]/input"));

      public static IWebElement SearchFormBtn => Driver.FindElement(By.XPath("/html/body/div[3]/form/div[2]/div[1]/div[2]/button"));

      public static ReadOnlyCollection<IWebElement> SearchResults => Driver.FindElements(By.ClassName("rc"));

      public static ReadOnlyCollection<IWebElement> SearchHrefResults => Driver.FindElements(By.TagName("a"));
   }
}
