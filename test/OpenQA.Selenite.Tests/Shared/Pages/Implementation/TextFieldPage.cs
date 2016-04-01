using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class TextFieldPage : WebBlock
    {
        public TextFieldPage(Session session) : base(session)
        {
        }

        public ITextField<TextFieldPage> Text
        {
            get { return new TextField<TextFieldPage>(this, By.Id("TextField")); }
        }
    }
}