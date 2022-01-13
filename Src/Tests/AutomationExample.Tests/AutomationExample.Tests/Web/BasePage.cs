using System;
using System.Diagnostics;
using System.Linq;
using AutomationExample.Tests.Extensions;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExample.Tests.Web;

public class BasePage
{
    #region Properties

    // Setup the local class log4net logger
    private static readonly ILog _logger = LogManager.GetLogger(typeof(BasePage));

    /// <summary>
    ///     Gets or sets the selenium web driver.
    /// </summary>
    public IWebDriver Driver { get; set; }

    /// <summary>
    ///     Gets or sets the wait.
    /// </summary>
    public WebDriverWait Wait { get; set; }

    /// <summary>
    ///     Active page model location / URL
    /// </summary>
    public string PageUrl { get; set; }

    /// <summary>
    ///     Port Number, if used
    /// </summary>
    public string PortNumber { get; set; } = "47080";

    /// <summary>
    ///     Active page model title
    /// </summary>
    public string PageTitle { get; set; }

    #endregion

    #region CTOR

    /// <summary>
    ///     Force all Page Objects that are created to use the overloaded constructor.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    private BasePage()
    {
        // Do nothing
    }

    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

    #endregion

    #region Helpers

    public void NavigateTo()
    {
        Driver.Navigate().GoToUrl(PageUrl);
        EnsurePageLoaded();
    }

    private void EnsurePageLoaded()
    {
        if (!Driver.EnsurePageLoaded(PageUrl, PageTitle)) throw new EntryPointNotFoundException("Broken");
    }

    public void WaitTillGone(By by)
    {
        WaitTillGone(by, TimeSpan.FromSeconds(30));
    }

    public void WaitTillGone(By by, TimeSpan timeSpan)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        while (Driver.FindElements(by).Any(e => e.Displayed))
            if (stopWatch.Elapsed.Seconds > timeSpan.Seconds)
                return;
    }

    public void WaitTill(TimeSpan timeSpan)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        while (true)
            if (stopWatch.Elapsed.Seconds > timeSpan.Seconds)
                return;
    }

    public IWebElement Element(string by)
    {
        return Element(by, 10);
    }

    public IWebElement Element(string by, int maxWaitSec)
    {
        return WaitBySeconds(maxWaitSec).Until(driver => Driver.FindElement(GetBy(by)));
    }

    public IWebElement Element(IWebElement element, int maxWaitSec)
    {
        return WaitBySeconds(maxWaitSec).Until(driver => element);
    }

    public IWebElement Element(By by)
    {
        return Wait.Until(d => d.FindElement(by));
    }

    public By GetBy(string findBy)
    {
        if (findBy.Contains("<") & findBy.Contains(">")) return By.TagName(findBy.Trim('<').Trim('>'));

        if (findBy.Contains("//")) return By.XPath(findBy);

        if ((findBy.Contains(".") | findBy.Contains("#") | findBy.Contains("[")) & !findBy.Contains("..")) return By.CssSelector(findBy);

        return By.Id(findBy);
    }

    public WebDriverWait WaitBySeconds(int seconds)
    {
        return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
    }

    #endregion
}