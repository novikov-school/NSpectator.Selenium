using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace OpenQA.Selenite.Extensions
{
    public static class JavaScriptExecution
    {
        public static IEnumerable<IWebElement> GetElementsByJQuery(this IWebDriver driver, string query)
        {
            return driver.ExecuteJavaScript<IEnumerable<IWebElement>>(string.Format("return $('{0}').get();", query));
        }

        public static T ExecuteFunction<T>(this IWebElement element, string function, params object[] args)
        {
            return element.GetDriver().ExecuteJavaScript<T>("arguments[0]." + function, element, args);
        }

        public static T ExecuteJQueryFunction<T>(this IWebElement element, string function, params object[] args)
        {
            return element.GetDriver().ExecuteJavaScript<T>("$(arguments[0])." + function, element, args);
        }
    }
}