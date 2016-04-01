using System;

namespace OpenQA.Selenite.Tests.Shared.Hosting
{
    /// <summary>
    /// Селф-хост
    /// </summary>
    public interface IHost : IDisposable
    {
        void Start();

        void Stop();
    }

    /// <summary>
    /// Спецификация теста
    /// </summary>
    public interface ITestSpec
    {
        void Before();

        void After();
    }
}