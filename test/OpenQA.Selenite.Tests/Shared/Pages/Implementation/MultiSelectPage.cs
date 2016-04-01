using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class MultiSelectPage : WebBlock
    {
        public MultiSelectPage(Session session) : base(session)
        {
        }

        public ISelectBox<MultiSelectPage> Toppings => new SelectBox<MultiSelectPage>(this, By.Id("MultiSelectBox"));
    }
}