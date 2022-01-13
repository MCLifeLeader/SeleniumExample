using log4net;
using OpenQA.Selenium;

namespace AutomationExample.Tests.Web.PageModels
{
    public class Home : Navigation
    {
        #region Properties

        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Home));

        #endregion

        public Home(IWebDriver driver) : base(driver)
        {
            PageTitle = "Automation Example Web Application";
            PageUrl = $"http://localhost:{PortNumber}";
        }

        #region Page Objects

        public IWebElement HomeParagraphElement => Driver.FindElement(By.XPath("/html/body/div[1]/main/article/div/div/p"));

        #endregion

        #region Page Actions

        #endregion
    }
}