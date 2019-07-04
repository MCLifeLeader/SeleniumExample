using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.Web.Extensions
{
   public static class WebElement
   {
      public static IWebElement FindByTextContains(this ReadOnlyCollection<IWebElement> webElements, string value)
      {
         return webElements.FirstOrDefault(e => e.Text.Normalize().Contains(value));
      }

      public static IWebElement FindByText(this ReadOnlyCollection<IWebElement> webElements, string value)
      {
         return webElements.FirstOrDefault(e => e.Text.Normalize() == value);
      }

      public static IWebElement FindByAttributeContains(this ReadOnlyCollection<IWebElement> webElements, string attribute, string value)
      {
         return webElements.FirstOrDefault(e => e.GetAttribute(attribute).Normalize().Contains(value));
      }

      public static IWebElement FindByAttribute(this ReadOnlyCollection<IWebElement> webElements, string attribute, string value)
      {
         return webElements.FirstOrDefault(e => e.GetAttribute(attribute).Normalize() == value);
      }

      public static void Set(this IWebElement webElement, string value)
      {
         webElement.Clear();
         webElement.SendKeys(value);
      }

      public static void CheckValue(this IWebElement webElement, string value = "")
      {
         switch (webElement.TagName)
         {
            case "input":
               switch (webElement.GetAttribute("type"))
               {
                  case "radio":
                     Assert.IsTrue(webElement.Selected == Convert.ToBoolean(value));
                     break;
                  case "checkbox":
                     Assert.IsTrue(webElement.Selected == Convert.ToBoolean(value));
                     break;
                  default:
                     Assert.AreEqual(webElement.GetAttribute("value"), value);
                     break;
               }

               break;
            default:
               Assert.AreEqual(webElement.Text, value);
               break;
         }
      }

      public static void CheckSelected(this IWebElement webElement)
      {
         Assert.IsTrue(webElement.Selected);
      }
   }
}
