using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages
{
    public class LoggedOutPage : WebBlock
    {
        public LoggedOutPage(Session session) : base(session)
        {
            Tag = FindElement(By.Id("login"));
        }
    }
}