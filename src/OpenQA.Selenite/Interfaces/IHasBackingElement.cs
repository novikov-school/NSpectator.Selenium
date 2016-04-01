using OpenQA.Selenium;

namespace OpenQA.Selenite.Interfaces
{
    public interface IHasBackingElement
    {
        IWebElement Tag { get; }
    }
}