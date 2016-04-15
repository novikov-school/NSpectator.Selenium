using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class UpgradePromptPage : WebBlock
    {
        public UpgradePromptPage(Session session) : base(session)
        {
        }

        public IClickable<LoggedInPage> NotNow => new Clickable<LoggedInPage>(this, By.CssSelector("a.button.notnow"));
    }
}