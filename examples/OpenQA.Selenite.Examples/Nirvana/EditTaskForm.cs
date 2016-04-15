using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class EditTaskForm : WebBlock
    {
        public EditTaskForm(Session session) : base(session)
        {
            Tag = FindElement(By.CssSelector(".task.edit"));
        }

        public ITextField<EditTaskForm> Name => new TextField<EditTaskForm>(this, By.Name("name"));

        public ITextField<EditTaskForm> Note => new TextField<EditTaskForm>(this, By.ClassName("note"));

        public IClickable<MainArea> Save => new Clickable<MainArea>(this, By.ClassName("save"));

        public IClickable<MainArea> Cancel => new Clickable<MainArea>(this, By.ClassName("cancel"));
    }
}