using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace OpenQA.Selenite.Extensions
{
    public static class WebElementConvenience
    {
        public static IWebDriver GetDriver(this IWebElement element)
        {
            return ((IWrapsDriver) element).WrappedDriver;
        }

        public static string GetId(this IWebElement element)
        {
            return element.GetAttribute("id");
        }

        public static IEnumerable<string> GetClasses(this IWebElement element)
        {
            return element.GetAttribute("class").Split(' ');
        }

        public static bool HasClass(this IWebElement element, string className)
        {
            return element.GetClasses().Any(@class => @class.Equals(className));
        }
    }
}