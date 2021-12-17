using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Selenium.Web.Tests.Model.Page.MbCarey
{
   public class Leadership : Navigation
   {
      public static ReadOnlyCollection<IWebElement> H2Elements => Driver.FindElements(By.TagName("h2"));
      public static ReadOnlyCollection<IWebElement> H3Elements => Driver.FindElements(By.TagName("h3"));
   }
}