using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Selenium.Web.Model.Page
{
   public class GoogleSearchResults : WebDriverConfig
   {
      public static IWebElement SearchForm => Driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[2]/div/div[1]/input"));

      public static IWebElement SearchFormBtn => Driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[2]/button"));

      public static ReadOnlyCollection<IWebElement> SearchResults => Driver.FindElements(By.ClassName("rc"));

      public static ReadOnlyCollection<IWebElement> SearchHrefResults => Driver.FindElements(By.TagName("a"));
   }
}
