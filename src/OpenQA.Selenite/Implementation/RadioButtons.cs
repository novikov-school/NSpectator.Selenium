using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenium;

namespace OpenQA.Selenite.Implementation
{
    public class RadioButtons<TResult> : IRadioButtons<TResult> where TResult : IBlock
    {

        public RadioButtons(IBlock parent, By by)
        {
            ParentBlock = parent;
            By = by;
        }

        private IBlock ParentBlock { get; set; }
        private By By { get; set; }

        public virtual IEnumerable<IOption<TResult>> Options
        {
            get
            {
                return ParentBlock.Tag.FindElements(By)
                    .Where(opt => opt.Displayed)
                    .Select(opt => new RadioButton<TResult>(ParentBlock, opt));
            }
        }
    }
}