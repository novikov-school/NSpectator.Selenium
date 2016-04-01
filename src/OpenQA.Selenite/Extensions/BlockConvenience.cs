using System;
using OpenQA.Selenite.Interfaces;

namespace OpenQA.Selenite.Extensions
{
    public static class BlockConvenience
    {
        public static TScope ScopeTo<TScope>(this IBlock block)
            where TScope : IBlock
        {
            return block.Session.CurrentBlock<TScope>();
        }
    }
}