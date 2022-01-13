using log4net;
using OpenQA.Selenium;

namespace AutomationExample.Tests.Extensions
{
    /// <summary>
    ///     WebDriver Extension methods
    /// </summary>
    public static class WebDriver
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(WebDriver));

        /// <summary>
        ///     Check to see if the page has loaded. This is primarily intended to be used to validate if a page object
        ///     has loaded successfully.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="url"></param>
        /// <param name="pageTitle"></param>
        /// <returns></returns>
        public static bool EnsurePageLoaded(this IWebDriver driver, string url, string pageTitle)
        {
            _logger.DebugFormat($"'{nameof(WebDriver)}.{nameof(EnsurePageLoaded)}' called");

            return driver.Url.Contains(url) && driver.Title.Contains(pageTitle);
        }
    }
}