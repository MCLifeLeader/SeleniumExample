using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Selenium.Web.Tests.Model.Page.Google
{
   public class SearchResults : WebDriverConfig
   {
      public static IWebElement SearchForm => Driver.FindElement(By.XPath("/html/body/div[3]/form/div[2]/div[1]/div[2]/div/div[2]/input"));

      public static IWebElement SearchFormBtn => Driver.FindElement(By.XPath("/html/body/div[3]/form/div[2]/div[1]/div[2]/button"));

      public static ReadOnlyCollection<IWebElement> SearchResultsCollection => Driver.FindElements(By.ClassName("rc"));

      public static ReadOnlyCollection<IWebElement> SearchHrefResultsCollection => Driver.FindElements(By.TagName("a"));

      // This returns the primary div that contains the page navigation links
      public static IWebElement BottomPageNavigation => Driver.FindElement(By.Id("navcnt"));
   }
}
