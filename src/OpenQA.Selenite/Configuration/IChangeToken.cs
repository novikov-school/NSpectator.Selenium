using System;

namespace Microsoft.Extensions.Primitives
{
    /// <summary>
    /// An <see cref="T:Microsoft.Extensions.Primitives.IChangeToken" />
    /// that is notified when a file is added, modified or deleted.
    /// 
    /// Вставляем заглушку
    /// </summary>
    public interface IChangeToken
    {
        bool ActiveChangeCallbacks { get; }

        bool HasChanged { get; }

        IDisposable RegisterChangeCallback(Action<object> callback, object state);

        void OnReload();
    }
}