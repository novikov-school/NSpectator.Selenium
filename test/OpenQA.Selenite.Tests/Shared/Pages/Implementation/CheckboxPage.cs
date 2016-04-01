using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class CheckboxPage : WebBlock
    {
        public CheckboxPage(Session session) : base(session)
        {
        }

        public ICheckbox<CheckboxPage> CheckedCheckbox
        {
            get { return new Checkbox<CheckboxPage>(this, By.Id("CheckedCheckbox")); }
        }

        public ICheckbox<CheckboxPage> UncheckedCheckbox
        {
            get { return new Checkbox<CheckboxPage>(this, By.Id("UncheckedCheckbox")); }
        }
    }
}