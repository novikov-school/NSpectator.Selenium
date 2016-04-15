using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class ToolBar : WebBlock
    {
        public ToolBar(Session session) : base(session)
        {
            Tag = FindElement(By.Id("north"));
        }

        public ITextField<ToolBar> SearchField => new TextField<ToolBar>(this, By.ClassName("q"));

        public IClickable<EditTaskForm> NewTask => new Clickable<EditTaskForm>(this, By.ClassName("newtask"));

        public IHasText Account => new TextField(this, By.CssSelector("a.right.button.accountmenu.xcmenu"));
    }
}