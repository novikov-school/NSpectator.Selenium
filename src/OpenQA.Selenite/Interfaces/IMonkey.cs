using System.Collections.Generic;

namespace OpenQA.Selenite.Interfaces
{
    public interface IMonkey
    {
        IList<string> Logs { get; }

        void Invoke(IBlock block);

        void VerifyState();
    }
}