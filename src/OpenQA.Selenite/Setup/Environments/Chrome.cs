using System;
using OpenQA.Selenium.Chrome;

namespace OpenQA.Selenite.Setup.Environments
{
    public class Chrome : SimpleDriverEnvironment<ChromeDriver>
    {
        public Chrome()
        {
        }

        public Chrome(TimeSpan timeToWait) : base(timeToWait)
        {
        }
    }
}