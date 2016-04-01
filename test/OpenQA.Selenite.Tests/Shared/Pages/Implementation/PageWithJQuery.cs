using System;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class PageWithJQuery : WebBlock
    {
        public PageWithJQuery(Session session) : base(session, TimeSpan.FromSeconds(5))
        {
        }
    }
}