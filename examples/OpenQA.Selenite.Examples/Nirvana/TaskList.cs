using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class TaskList : SpecificBlock
    {
        public TaskList(Session session, IWebElement tag) : base(session, tag)
        {
        }

        public string Name => FindElement(By.ClassName("name")).Text;

        public IEnumerable<TaskRow> TaskRows
        {
            get
            {
                return FindElement(By.ClassName("tasks"))
                    .FindElements(By.ClassName("task"))
                    .Select(tag => new TaskRow(Session, tag));
            }
        }
    }
}