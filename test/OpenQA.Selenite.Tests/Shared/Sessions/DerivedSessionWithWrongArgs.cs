using OpenQA.Selenite.Interfaces;
using OpenQA.Selenite.Setup;

namespace OpenQA.Selenite.Tests.Shared.Sessions
{
    public class DerivedSessionWithWrongArgs : Session
    {
        public DerivedSessionWithWrongArgs(IDriverEnvironment environment, IMonkey monkey) : base(environment)
        {
            Monkey = monkey;
        }
    }
}