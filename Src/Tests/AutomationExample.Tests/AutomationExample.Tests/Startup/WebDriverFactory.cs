using System;
using System.Data;
using AutomationExample.Tests.Model.Enum;
using log4net;
using Microsoft.Edge.SeleniumTools;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationExample.Tests.Startup
{
    /// <summary>
    ///     A Mechanism for creating browser session for Selenium based UI automation testing.
    /// </summary>
    public class WebDriverFactory
    {
        #region CTOR

        /// <summary>
        ///     Initialize custom values for the timeouts and webdriver types.
        /// </summary>
        /// <param name="config">Custom Configuration Settings from appsettings.json</param>
        /// <exception cref="ArgumentNullException"></exception>
        public WebDriverFactory(IConfiguration config)
        {
            Configuration = config ?? throw new ArgumentNullException(nameof(config), "Parameter must be be initialized prior to calling this class");

            TimeoutPageLoadSecs = int.Parse(Configuration
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["PageLoadTimeoutInSeconds"]);

            TimeoutImplicitWaitSecs = int.Parse(Configuration
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["ImplicitWaitInSeconds"]);

            TimeoutJavascriptSecs = int.Parse(Configuration
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["JavascriptTimeoutInSeconds"]);

            TimeoutCommandSecs = int.Parse(Configuration
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["TimeoutCommandSecs"]);

            HeadlessBrowser = bool.Parse(Configuration
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["HeadlessBrowser"]);

            Enum.TryParse(Configuration
                .GetSection("AppSettings")
                .GetSection("WebBrowserConfiguration")["BrowserType"], true, out WebDriverType driverType);
            BrowserType = driverType;
        }

        #endregion

        #region Properties

        // Setup the local class log4net logger
        private static readonly ILog _logger = LogManager.GetLogger(typeof(WebDriverFactory));

        /// <summary>
        ///     Set the base implicit amount of time to wait before timing out
        /// </summary>
        protected int TimeoutImplicitWaitSecs { get; set; } = 10;

        /// <summary>
        ///     Set the amount of time to allow a web page to load before timing out
        /// </summary>
        protected int TimeoutPageLoadSecs { get; set; } = 300;

        /// <summary>
        ///     Amount of time to allow JavaScript to execute before timing out
        /// </summary>
        protected int TimeoutJavascriptSecs { get; set; } = 30;

        /// <summary>
        ///     Cammand timeout in seconds
        /// </summary>
        protected int TimeoutCommandSecs { get; set; } = 60;

        /// <summary>
        ///     Set the browser to be displayed visually or hidden
        /// </summary>
        protected bool HeadlessBrowser { get; set; }

        /// <summary>
        ///     Represents the data stored and found within appsettings.json
        /// </summary>
        protected IConfiguration Configuration { get; set; }

        /// <summary>
        ///     Set the browser type to be launched and run the UI automation within
        /// </summary>
        protected WebDriverType BrowserType { get; set; } = WebDriverType.Chrome;

        #endregion

        #region Factory Methods

        /// <summary>
        ///     Initialize a browser instance for UI automation
        /// </summary>
        /// <returns>Instantiated WebDriver instance</returns>
        /// <exception cref="NoNullAllowedException"></exception>
        public IWebDriver Initialize()
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(Initialize)}' called");

            if (Configuration == null)
                throw new NoNullAllowedException(
                    $"Configuration not set. Init Config or call overloaded method WebDriverFactory.Initialize({typeof(WebDriverType)})");

            return Initialize(BrowserType);
        }

        /// <summary>
        ///     Initialize a browser instance for UI automation
        /// </summary>
        /// <param name="webDriverType">Custom Browser Instance</param>
        /// <param name="arguments">Additional configuration actions for the WebDriver instance to be passed into the browser</param>
        /// <returns>Instantiated WebDriver instance</returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public IWebDriver Initialize(WebDriverType webDriverType, params string[] arguments)
        {
            _logger.DebugFormat($"'{GetType().Name}.{nameof(Initialize)}' called");

            IWebDriver driver;

            // User selected browser type
            switch (webDriverType)
            {
                case WebDriverType.FireFox:
                case WebDriverType.Gecko:
                    // Firefox Driver Stub
                    FirefoxOptions fireFoxOptions = new FirefoxOptions();
                    fireFoxOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    fireFoxOptions.AcceptInsecureCertificates = true;
                    if (HeadlessBrowser) fireFoxOptions.AddArgument("--headless");

                    if (arguments != null && arguments.Length > 0)
                        foreach (string argument in arguments)
                            fireFoxOptions.AddArgument(argument);

                    FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService();
                    firefoxDriverService.HideCommandPromptWindow = true;
                    firefoxDriverService.SuppressInitialDiagnosticInformation = true;
                    driver = new FirefoxDriver(firefoxDriverService, fireFoxOptions, TimeSpan.FromSeconds(TimeoutImplicitWaitSecs));
                    //driver = new FirefoxDriver();
                    break;
                case WebDriverType.Chrome:
                    // Chrome Driver Stub
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    chromeOptions.AcceptInsecureCertificates = true;
                    chromeOptions.AddArgument("use-fake-ui-for-media-stream");
                    chromeOptions.AddArgument("no-sandbox");
                    if (HeadlessBrowser) chromeOptions.AddArgument("--headless");

                    if (arguments != null && arguments.Length > 0)
                        foreach (string argument in arguments)
                            chromeOptions.AddArgument(argument);

                    ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                    chromeDriverService.HideCommandPromptWindow = true;
                    chromeDriverService.SuppressInitialDiagnosticInformation = true;
                    driver = new ChromeDriver(chromeDriverService, chromeOptions, TimeSpan.FromSeconds(TimeoutImplicitWaitSecs));
                    //driver = new ChromeDriver();
                    break;
                case WebDriverType.Edge:
                    // Microsoft Edge Driver Stub
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    edgeOptions.UseChromium = true; // Microsoft.Edge.SeleniumTools
                    edgeOptions.UseWebView = true;
                    edgeOptions.AcceptInsecureCertificates = true;
                    if (HeadlessBrowser) edgeOptions.AddArgument("headless");

                    if (arguments != null && arguments.Length > 0)
                        foreach (string argument in arguments)
                            edgeOptions.AddArgument(argument);

                    EdgeDriverService edgeService = EdgeDriverService.CreateChromiumService();
                    edgeService.HideCommandPromptWindow = true;
                    edgeService.SuppressInitialDiagnosticInformation = true;
                    driver = new EdgeDriver(edgeService, edgeOptions, TimeSpan.FromSeconds(TimeoutImplicitWaitSecs));
                    //driver = new EdgeDriver();
                    break;
                case WebDriverType.Opera:
                    throw new NotImplementedException($"Opera Driver Initialization not ready: {webDriverType}");
                case WebDriverType.Safari:
                    throw new NotImplementedException($"Safari Driver Initialization not ready: {webDriverType}");
                case WebDriverType.InternetExplorer:
                    throw new NotImplementedException($"IE Initialization not ready: {webDriverType}");
                default:
                    throw new ArgumentException($"Browser was not initialized {webDriverType}", nameof(webDriverType));
            }

            if (TimeoutImplicitWaitSecs > 0) driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeoutImplicitWaitSecs);

            if (TimeoutPageLoadSecs > 0) driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TimeoutPageLoadSecs);

            if (TimeoutJavascriptSecs > 0) driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(TimeoutJavascriptSecs);

            driver.Manage().Window.Maximize();
            // This is provided as an example for changing the resolution on your browser session.
            // WebDriverConfig.Driver.Manage().Window.Size = new System.Drawing.Size( 1920, 1080 );

            return driver;
        }

        #endregion
    }
}