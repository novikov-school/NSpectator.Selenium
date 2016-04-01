using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Sessions
{
    public class DerivedSession : Session
    {
        public DerivedSession(IDriverEnvironment environment) : base(environment)
        {
        }
    }
}