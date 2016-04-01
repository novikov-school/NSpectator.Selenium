using System;
using OpenQA.Selenium.Firefox;

namespace OpenQA.Selenite.Setup.Environments
{
    public class Firefox : SimpleDriverEnvironment<FirefoxDriver>
    {
        public Firefox()
        {
        }

        public Firefox(TimeSpan timeToWait) : base(timeToWait)
        {
        }
    }
}