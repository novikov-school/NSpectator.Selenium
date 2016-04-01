using OpenQA.Selenium;

namespace OpenQA.Selenite.Setup
{
    public interface IDriverEnvironment
    {
        IWebDriver CreateWebDriver();

        IWebDriver CreateWebDriver(string proxy);
    }
}