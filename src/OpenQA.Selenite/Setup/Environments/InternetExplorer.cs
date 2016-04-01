using System;
using OpenQA.Selenium.IE;

namespace OpenQA.Selenite.Setup.Environments
{
    public class InternetExplorer : SimpleDriverEnvironment<InternetExplorerDriver>
    {
        public InternetExplorer()
        {
        }

        public InternetExplorer(TimeSpan timeToWait) : base(timeToWait)
        {
        }
    }
}