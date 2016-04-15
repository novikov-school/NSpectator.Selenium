using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class LoggedInPage : WebBlock
    {
        public LoggedInPage(Session session)
            : base(session)
        {
            Wait.Until(driver => driver.FindElement(By.Id("north")));
            Tag = Session.Driver.FindElement(By.TagName("body"));
        }

        public ToolBar ToolBar => new ToolBar(Session);

        public SideBar SideBar => new SideBar(Session);

        public MainArea MainArea => new MainArea(Session);
    }
}