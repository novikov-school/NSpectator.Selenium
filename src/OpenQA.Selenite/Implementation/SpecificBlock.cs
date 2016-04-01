using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;
using OpenQA.Selenium;

namespace OpenQA.Selenite.Implementation
{
    public abstract class SpecificBlock : Block, ISpecificBlock
    {
        protected SpecificBlock(Session session, IWebElement tag) : base(session)
        {
            Tag = tag;
        }
    }
}