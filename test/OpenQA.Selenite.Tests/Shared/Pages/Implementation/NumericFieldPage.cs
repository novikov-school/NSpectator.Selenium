using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class NumericFieldPage : WebBlock
    {
        public NumericFieldPage(Session session) : base(session)
        {
        }

        public INumericField<NumericFieldPage> Number
        {
            get { return new NumericField<NumericFieldPage>(this, By.Id("NumericField")); }
        }
    }
}