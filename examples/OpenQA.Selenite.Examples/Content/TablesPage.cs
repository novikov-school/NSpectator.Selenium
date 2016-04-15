using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Content
{
    public class TablesPage : WebBlock
    {
        public TablesPage(Session session) : base(session)
        {
        }

        public ITable TableInAscendingOrder
        {
            get { return new Table(this, By.Id("inAscendingOrder")); }
        }

        public ITable TableInDescendingOrder
        {
            get { return new Table(this, By.Id("inDescendingOrder")); }
        }
    }
}