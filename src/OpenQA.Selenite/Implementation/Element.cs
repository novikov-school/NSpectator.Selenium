using OpenQA.Selenite.Interfaces;
using OpenQA.Selenium;

namespace OpenQA.Selenite.Implementation
{
    public abstract class Element : SpecificBlock
    {

        protected Element(IBlock parent, By by) 
            : base(parent.Session, parent.Tag.FindElement(by))
        {
            ParentBlock = parent;
        }

        protected Element(IBlock parent, IWebElement tag) 
            : base(parent.Session, tag)
        {
            ParentBlock = parent;
        }

        public IBlock ParentBlock { get; private set; }

        public virtual string Text => Tag.Text;

        public virtual bool Selected => Tag.Selected;
    }
}