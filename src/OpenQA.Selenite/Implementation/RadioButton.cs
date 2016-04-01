using OpenQA.Selenite.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenite.Extensions;

namespace OpenQA.Selenite.Implementation
{
    public class RadioButton<TResult> : Option<TResult> where TResult : IBlock
    {
        public RadioButton(IBlock parent, By by) : base(parent, by)
        {
        }

        public RadioButton(IBlock parent, IWebElement element) : base(parent, element)
        {
        }

        public override string Text
        {
            get { return ParentBlock.Tag.FindElement(By.CssSelector("label[for=\"" + Tag.GetId() + "\"]")).Text; }
        }
    }
}