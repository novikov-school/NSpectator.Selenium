using System.Collections.Generic;

namespace OpenQA.Selenite.Interfaces
{
    public interface IRadioButtons<out TResult> where TResult : IBlock
    {
        IEnumerable<IOption<TResult>> Options { get; }
    }
}