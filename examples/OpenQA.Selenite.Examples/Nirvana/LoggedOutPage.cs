using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Nirvana
{
    public class LoggedOutPage : WebBlock
    {
        public LoggedOutPage(Session session) : base(session)
        {
        }

        public ITextField<LoggedOutPage> Username
        {
            get { return new TextField<LoggedOutPage>(this, By.Id("user")); }
        }

        public ITextField<LoggedOutPage> Password
        {
            get { return new TextField<LoggedOutPage>(this, By.Id("pass")); }
        }

        public IClickable Login
        {
            get { return new Clickable(this, By.Id("btn-submit")); }
        }

        public IHasText Error
        {
            get { return new TextField(this, By.ClassName("formerror")); }
        }
    }
}