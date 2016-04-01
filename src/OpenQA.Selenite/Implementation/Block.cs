using System;
using System.Collections.Generic;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;
using OpenQA.Selenium;

namespace OpenQA.Selenite.Implementation
{
    public abstract class Block : IBlock
    {
        protected Block(Session session)
        {
            Session = session;
            Session.Monkey?.Invoke(this);
        }

        public Session Session { get; private set; }

        public IWebElement Tag { get; protected set; }

        public virtual IPerformsDragAndDrop GetDragAndDropPerformer()
        {
            return new WebDragAndDropPerformer(Session.Driver);
        }

        public virtual void VerifyMonkeyState()
        {
        }

        public IList<IWebElement> FindElements(By by)
        {
            if (Tag == null)
            {
                throw new NullReferenceException("You can't call GetElements on a block without first initializing Tag.");
            }

            return Tag.FindElements(by);
        }

        public IWebElement FindElement(By by)
        {
            if (Tag == null)
            {
                throw new NullReferenceException("You can't call GetElement on a block without first initializing Tag.");
            }

            return Tag.FindElement(by);
        }
    }
}