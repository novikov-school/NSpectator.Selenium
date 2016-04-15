using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class SideBar : WebBlock
    {
        public SideBar(Session session) : base(session)
        {
            Tag = FindElement(By.Id("east"));
        }

        public IWebElement Trash
        {
            get { return FindElement(By.ClassName("trash")); }
        }
    }
}