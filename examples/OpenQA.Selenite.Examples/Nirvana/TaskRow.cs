using OpenQA.Selenium;
using OpenQA.Selenite.Extensions;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class TaskRow : SpecificBlock
    {
        public TaskRow(Session session, IWebElement tag) : base(session, tag)
        {
        }

        public string Name => FindElement(By.CssSelector("span.name.edittask")).Text;

        public IClickable<TaskRow> Complete => new Clickable<TaskRow>(this, By.CssSelector("span.i.check"));

        public void Delete()
        {
            var drag = FindElement(By.CssSelector("span.i.drag.project"));
            var drop = new SideBar(Session).Trash;

            GetDragAndDropPerformer()
                .DragAndDrop(drag, drop);

            Session.Pause(200);

        }
    }
}