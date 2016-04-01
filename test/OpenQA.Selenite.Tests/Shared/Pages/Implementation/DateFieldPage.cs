using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class DateFieldPage : WebBlock
    {
        public DateFieldPage(Session session)
            : base(session)
        {
        }

        public IDateField<DateFieldPage> Date
        {
            get { return new DateField<DateFieldPage>(this, By.Id("DateField")); }
        }
    }
}