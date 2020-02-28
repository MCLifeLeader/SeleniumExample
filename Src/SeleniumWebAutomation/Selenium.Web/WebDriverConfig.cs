using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.Web.Model;

namespace Selenium.Web
{
   public class WebDriverConfig
   {
      #region Accessors
      /// <summary>
      /// Gets or sets the service end point.
      /// </summary>
      /// <value>
      /// The service end point.
      /// </value>
      public static string ServiceEndPoint { get; set; }
      /// <summary>
      /// Gets or sets the driver.
      /// </summary>
      /// <value>
      /// The driver.
      /// </value>
      public static IWebDriver Driver { get; set; }
      /// <summary>
      /// Gets or sets the user context.
      /// </summary>
      /// <value>
      /// The user context.
      /// </value>
      public static UserContext UserContext { get; set; }
      /// <summary>
      /// Gets or sets the wait.
      /// </summary>
      /// <value>
      /// The wait.
      /// </value>
      public static WebDriverWait Wait { get; set; }
      /// <summary>
      /// Gets or sets the wait5.
      /// </summary>
      /// <value>
      /// The wait5.
      /// </value>
      public static WebDriverWait Wait5 { get; set; }
      /// <summary>
      /// Gets or sets the wait10.
      /// </summary>
      /// <value>
      /// The wait10.
      /// </value>
      public static WebDriverWait Wait10 { get; set; }

      /// <summary>
      /// Gets or sets the wait30.
      /// </summary>
      /// <value>
      /// The wait30.
      /// </value>
      public static WebDriverWait Wait30 { get; set; }

      #endregion

      public static void WaitTillGone(By by)
      {
         WaitTillGone(by, TimeSpan.FromSeconds(30));
      }

      public static void WaitTillGone(By by, TimeSpan timeSpan)
      {
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();

         while (Driver.FindElements(by).Any(e => e.Displayed))
         {
            if (stopWatch.Elapsed.Seconds > timeSpan.Seconds)
               return;
         }
      }

      public static void WaitTill(TimeSpan timeSpan)
      {
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();

         while (true)
         {
            if (stopWatch.Elapsed.Seconds > timeSpan.Seconds)
               return;
         }
      }

      public static IWebElement Element(string by)
      {
         return Element(by, 10);
      }

      public static IWebElement Element(string by, int maxWaitSec)
      {
         return WaitBySeconds(maxWaitSec).Until(driver => Driver.FindElement(GetBy(by)));
      }

      public static IWebElement Element(IWebElement element, int maxWaitSec)
      {
         return WaitBySeconds(maxWaitSec).Until(driver => element);
      }

      public static IWebElement Element(By by)
      {
         return Wait.Until(d => d.FindElement(by));
      }

      public static void WaitToBeDisplayed(By by, TimeSpan timeSpan)
      {
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();

         while (!Driver.FindElements(by).Any(e => e.Displayed))
         {
            if (stopWatch.Elapsed.Seconds > timeSpan.Seconds)
               return;
         }
      }

      /// <summary>
      /// Closes the window by URL or handle.
      /// </summary>
      /// <param name="urlOrHandle">The URL or handle.</param>
      /// <param name="timeSpan">The time span.</param>
      /// <param name="byHandle">if set to <c>true</c> [by handle].</param>
      /// <returns>true if closed, false if nothing found or closed</returns>
      public static bool CloseWindowByUrlOrHandle(string currentHandle, string urlOrHandle, TimeSpan timeSpan, bool byHandle = false)
      {
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();

         while (stopWatch.Elapsed.Seconds < timeSpan.Seconds)
         {
            if (byHandle)
            {
               Driver.SwitchTo().Window(urlOrHandle);
               Driver.Close();
               Driver.SwitchTo().Window(currentHandle);

               return true;
            }

            foreach (string handle in Driver.WindowHandles)
            {
               Driver.SwitchTo().Window(handle);

               if (Driver.Url.Contains(urlOrHandle) || Driver.Title.Contains(urlOrHandle))
               {
                  Driver.Close();
                  Driver.SwitchTo().Window(currentHandle);
                  return true;
               }

               Thread.Sleep(100);
            }
         }

         return false;
      }

      /// <summary>
      /// Keep trying to access an alternate webpage for a period of time
      /// </summary>
      /// <param name="urlOrHandle">The URL or handle.</param>
      /// <param name="timeSpan">The time span.</param>
      /// <param name="byHandle">if set to <c>true</c> [by handle].</param>
      /// <exception cref="NoSuchWindowException">Unable to find Window:  + urlOrHandle</exception>
      public static void SwitchToWindowByUrlOrHandle(string urlOrHandle, TimeSpan timeSpan, bool byHandle = false)
      {
         Stopwatch stopWatch = new Stopwatch();
         stopWatch.Start();

         while (stopWatch.Elapsed.Seconds < timeSpan.Seconds)
         {
            if (byHandle)
            {
               Driver.SwitchTo().Window(urlOrHandle);
               return;
            }

            foreach (string handle in Driver.WindowHandles)
            {
               Driver.SwitchTo().Window(handle);

               if (Driver.Url.Contains(urlOrHandle))
               {
                  return;
               }

               Thread.Sleep(100);
            }
         }

         throw new NoSuchWindowException("Unable to find Window: " + urlOrHandle);
      }

      public static void SwitchToBaseWindow()
      {
         Driver.SwitchTo().Window(Driver.WindowHandles[0]);
      }

      #region Helpers
      private static By GetBy(string findBy)
      {
         if (findBy.Contains("<") & findBy.Contains(">"))
         {
            return By.TagName(findBy.Trim('<').Trim('>'));
         }
         if (findBy.Contains("//"))
         {
            return By.XPath(findBy);
         }
         if ((findBy.Contains(".") | findBy.Contains("#") | findBy.Contains("[")) & (!findBy.Contains("..")))
         {
            return By.CssSelector(findBy);
         }

         return By.Id(findBy);
      }

      private static WebDriverWait WaitBySeconds(int seconds)
      {
         return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
      }
      #endregion
   }
}
