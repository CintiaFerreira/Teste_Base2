using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TesteBase2.Objetos
{
    public static class Extensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int waitSeconds)
        {
            if (waitSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
