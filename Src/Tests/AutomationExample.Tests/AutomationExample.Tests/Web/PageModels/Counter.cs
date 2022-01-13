using log4net;
using OpenQA.Selenium;

namespace AutomationExample.Tests.Web.PageModels
{
    public class Counter : Navigation
    {
        #region Properties

        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Counter));

        #endregion

        public Counter(IWebDriver driver) : base(driver)
        {
            PageTitle = "Counter";
            PageUrl = $"http://localhost:{PortNumber}/counter";
        }

        #region Page Actions

        public void ClickCounterButton()
        {
            CounterButton.Click();
        }

        #endregion

        #region Page Objects

        public IWebElement CounterParagraphElement => Driver.FindElement(By.XPath("/html/body/div[1]/main/article/p"));
        public IWebElement CounterButton => Driver.FindElement(By.CssSelector("body > div.page > main > article > button"));

        #endregion
    }
}