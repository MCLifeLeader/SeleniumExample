using log4net;
using OpenQA.Selenium;

namespace AutomationExample.Tests.Web.PageModels
{
    public class Navigation : BasePage
    {
        #region Properties

        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Navigation));

        #endregion

        #region Page Objects

        public IWebElement PageTitleLink => Driver.FindElement(By.CssSelector(".navbar-brand"));
        public IWebElement HomeLink => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/nav/div[1]/a"));
        public IWebElement CounterLink => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/nav/div[2]/a"));
        public IWebElement FetchDataLink => Driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/nav/div[3]/a"));

        #endregion

        public Navigation(IWebDriver driver) : base(driver)
        {
            PageTitle = "Automation Example Web Application";
            PageUrl = $"http://localhost:{PortNumber}";
        }

        #region Page Actions

        public Home ClickHomeAndNavigate()
        {
            HomeLink.Click();

            return new Home(Driver);
        }

        public Counter ClickCounterAndNavigate()
        {
            CounterLink.Click();

            return new Counter(Driver);
        }

        public FetchData ClickFetchDataAndNavigate()
        {
            FetchDataLink.Click();

            return new FetchData(Driver);
        }

        #endregion
    }
}
