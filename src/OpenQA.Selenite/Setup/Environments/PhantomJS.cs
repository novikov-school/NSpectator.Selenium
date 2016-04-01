using System;
using OpenQA.Selenium.PhantomJS;

namespace OpenQA.Selenite.Setup.Environments
{
    // ReSharper disable InconsistentNaming

    public class PhantomJS : SimpleDriverEnvironment<PhantomJSDriver>
    {
        public PhantomJS()
        {
        }

        public PhantomJS(TimeSpan timeToWait) : base(timeToWait)
        {
        }
    }
}