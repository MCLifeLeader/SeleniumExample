using System.Collections;
using System.Collections.Generic;
using Docker.DotNet.Models;
using log4net;
using OpenQA.Selenium;

namespace AutomationExample.Tests.Web.PageModels
{
    public class FetchData : Navigation
    {
        #region Properties

        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(FetchData));

        #endregion

        #region Page Objects

        public IWebElement FetchDataArticleElement => Driver.FindElement(By.XPath("/html/body/div[1]/main/article"));
        public IEnumerable<IWebElement> FetchDataTableRows => Driver.FindElements(By.TagName("tr"));

        #endregion

        public FetchData(IWebDriver driver) : base(driver)
        {
            PageTitle = "Weather forecast";
            PageUrl = $"http://localhost:{PortNumber}/fetchdata";
        }

        #region Page Actions
        #endregion
    }
}
