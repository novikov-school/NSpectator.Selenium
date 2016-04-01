using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenium;

namespace OpenQA.Selenite.Implementation
{
    public class Table : Element, ITable
    {
        public Table(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public Table(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public IEnumerable<string> Headers
        {
            get
            {
                return FindElement(By.TagName("thead"))
                    .FindElement(By.TagName("tr"))
                    .FindElements(By.TagName("th"))
                    .Select(x => x.Text);
            }
        }

        public IEnumerable<ITableRow> Rows
        {
            get
            {
                return FindElement(By.TagName("tbody"))
                    .FindElements(By.TagName("tr"))
                    .Select(
                        (x, i) => new TableRow(this, By.CssSelector($"tbody > tr:nth-child({i + 1})")));
            }
        }

        public IEnumerable<string> Footers
        {
            get
            {
                return FindElement(By.TagName("tfoot"))
                    .FindElement(By.TagName("tr"))
                    .FindElements(By.TagName("td"))
                    .Select(x => x.Text);
            }
        }

        public T HeaderAs<T>()
            where T : Element
        {
            return Create<T>(this, By.TagName("thead"));
        }

        public IEnumerable<T> RowsAs<T>()
            where T : Element
        {
            return FindElement(By.TagName("tbody"))
                  .FindElements(By.TagName("tr"))
                  .Select((x, i) => Create<T>(this, By.CssSelector($"tbody > tr:nth-child({i + 1})")));
        }

        public T FooterAs<T>()
            where T : Element
        {
            return Create<T>(this, By.TagName("tfoot"));
        }

        protected static T Create<T>(IBlock parent, By @by)
        {
            return (T) Activator.CreateInstance(typeof (T), parent, @by);
        }

        protected static T Create<T>(IBlock parent, IWebElement tag)
        {
            return (T) Activator.CreateInstance(typeof (T), parent, tag);
        }
    }
}