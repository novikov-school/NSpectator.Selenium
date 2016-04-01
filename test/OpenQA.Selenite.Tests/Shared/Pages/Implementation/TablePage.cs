using System;
using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class TablePage : WebBlock
    {
        public TablePage(Session session) : base(session)
        {
        }

        public TablePage(Session session, TimeSpan timeout) : base(session, timeout)
        {
        }

        public ITable Table
        {
            get { return new Table(this, By.Id("DataGrid")); }
        }
    }
}