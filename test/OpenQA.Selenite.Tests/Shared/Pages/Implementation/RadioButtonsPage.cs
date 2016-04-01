using System;
using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class RadioButtonsPage : WebBlock
    {
        public RadioButtonsPage(Session session, TimeSpan timeout) : base(session, timeout)
        {
        }

        public RadioButtonsPage(Session session) : base(session)
        {
        }

        public RadioButtons<RadioButtonsPage> Beverages
        {
            get { return new RadioButtons<RadioButtonsPage>(this, By.Name("beverages")); }
        }
    }
}