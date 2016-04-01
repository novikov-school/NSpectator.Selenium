namespace OpenQA.Selenite.Interfaces
{
    using Setup;

    public interface IHasSession : IConfigurable
    {
        Session Session { get; }
    }
}