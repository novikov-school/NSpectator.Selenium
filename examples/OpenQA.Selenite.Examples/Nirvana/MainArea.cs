using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class MainArea : WebBlock
    {
        public MainArea(Session session) : base(session)
        {
            Tag = FindElement(By.Id("main"));
        }

        public IEnumerable<TaskList> TaskLists
        {
            get
            {
                return FindElements(By.ClassName("tasklist"))
                    .Select(x => new TaskList(Session, x));
            }
        }
    }
}