using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Selenium.Web.Model.Page
{
   public class MbCareyTechnologies : WebDriverConfig
   {
      public static IWebElement MainPageText => Driver.FindElement(By.XPath("/html/body/div[1]/partial/main/h2"));
      public static ReadOnlyCollection<IWebElement> HyperLinkList => Driver.FindElements(By.TagName("a"));
      public static IWebElement QualityAssuranceLink => Driver.FindElement(By.XPath("/html/body/div[1]/partial/main/div/div[7]/p[2]/a"));
   }
}
