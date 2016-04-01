using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenite.Implementation;
using OpenQA.Selenite.Interfaces;

namespace OpenQA.Selenite.Tests.Shared.Pages.Implementation
{
    public class GenericTableRow : Element
    {
        private const int ItemColumnIndex = 0;
        private const int QuantityColumnIndex = 1;
        private const int PriceColumnIndex = 2;

        public GenericTableRow(IBlock parent, By @by) : base(parent, @by)
        {
        }

        public GenericTableRow(IBlock parent, IWebElement tag) : base(parent, tag)
        {
        }

        public string Item
        {
            get
            {
                return FindElements(By.TagName("td"))
                    .ElementAt(ItemColumnIndex)
                    .Text;
            }
        }

        public int Quantity
        {
            get
            {
                var text = FindElements(By.TagName("td"))
                    .ElementAt(QuantityColumnIndex)
                    .Text;

                return int.Parse(text);
            }
        }

        public decimal Price
        {
            get
            {
                var text = FindElements(By.TagName("td"))
                    .ElementAt(PriceColumnIndex)
                    .Text;

                return decimal.Parse(text);
            }
        }
    }
}