using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Examples.Reddit
{
    public class LoggedOutPage : RedditPage
    {
        public LoggedOutPage(Session session) : base(session)
        {
        }

        public LoginArea LoginArea => new LoginArea(Session);
    }

    public class LoginArea : WebBlock
    {
        public LoginArea(Session session) : base(session)
        {
            Tag = FindElement(By.Id("login_login-main"));
        }

        public ITextField<LoginArea> Email => new TextField<LoginArea>(this, By.Name("user"));

        public ITextField<LoginArea> Password => new TextField<LoginArea>(this, By.Name("passwd"));

        public IClickable<LoggedInPage> LoginButton => new Clickable<LoggedInPage>(this, By.TagName("button"));
    }
}