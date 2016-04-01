using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class KeysPage : WebBlock
    {
        public KeysPage(Session session) : base(session)
        {
        }

        public ITextField<KeysPage> KeysText
        {
            get { return new TextField<KeysPage>(this, By.Id("KeysTextArea")); }
        }

        public string KeyPressed
        {
            get { return FindElement(By.Id("KeyPressed")).Text; }
        }
    }
}