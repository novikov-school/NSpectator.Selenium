using System;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OpenQA.Selenite.Implementation
{
    public class AlertDialog : Block, IAlertDialog
    {

        public AlertDialog(Session session) : base(session)
        {
            Parent = null;
            Alert = WaitForAlert();
        }

        public AlertDialog(IWebElement parent, Session session) : base(session)
        {
            Parent = parent;
            Alert = WaitForAlert();
        }

        private IWebElement Parent { get; set; }

        private IAlert Alert { get; set; }

        public virtual TResult Accept<TResult>() where TResult : IBlock
        {
            Alert.Accept();
            return Session.CurrentBlock<TResult>(Parent);
        }

        public virtual TResult Dismiss<TResult>() where TResult : IBlock
        {
            Alert.Dismiss();
            return Session.CurrentBlock<TResult>(Parent);
        }

        public virtual IAlertDialog EnterText(string text)
        {
            Alert.SendKeys(text);
            return this;
        }

        public virtual string Text => Alert.Text;

        private IAlert WaitForAlert()
        {
            var wait = new WebDriverWait(Session.Driver, new TimeSpan(0, 0, 5));
            return wait.Until(d => d.SwitchTo().Alert());
        }
    }
}