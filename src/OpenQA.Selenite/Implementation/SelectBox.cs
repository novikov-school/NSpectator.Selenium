using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenium;

namespace OpenQA.Selenite.Implementation
{
    public class SelectBox : Element, ISelectBox
    {
        public SelectBox(IBlock parent, By by) : base(parent, by)
        {
            OptionsEvaluator = DefaultEvaluator;
        }

        public SelectBox(IBlock parent, IWebElement element) : base(parent, element)
        {
            OptionsEvaluator = DefaultEvaluator;
        }

        protected Func<IWebElement, IOption> DefaultEvaluator
        {
            get
            {
                return (e) => new Option(this, e); 
                
            }
        }

        public virtual IEnumerable<IOption> GetOptions()
        {
            return FindElements(By.TagName("option")).Select(OptionsEvaluator);
        }

        public Func<IWebElement, IOption> OptionsEvaluator;
    }

    public class SelectBox<TResult> : SelectBox, ISelectBox<TResult>
        where TResult : IBlock
    {
        public SelectBox(IBlock parent, By by) : base(parent, by)
        {
            OptionsEvaluator = GenericEvaluator;
        }

        public SelectBox(IBlock parent, IWebElement element) : base(parent, element)
        {
            OptionsEvaluator = GenericEvaluator;
        }

        protected Func<IWebElement, IOption<TResult>> GenericEvaluator
        {
            get
            {
                return (e) => new Option<TResult>(ParentBlock, e);
            }
        }

        public virtual IEnumerable<IOption<TResult>> Options
        {
            get { return FindElements(By.TagName("option")).Select(GenericEvaluator); }
        }
    }
}