﻿using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Selenium.Web.Tests.Model.Page.MbCarey
{
   public class Technologies : Navigation
   {
      public static ReadOnlyCollection<IWebElement> HyperLinkList => Driver.FindElements(By.TagName("a"));
      public static IWebElement MainPageText => Driver.FindElement(By.XPath("/html/body/div[1]/partial/main/h2"));
      public static IWebElement QualityAssuranceLink => Driver.FindElement(By.XPath("/html/body/div[1]/partial/main/div/div[7]/p[2]/a"));
   }
}
