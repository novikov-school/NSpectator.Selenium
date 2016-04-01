namespace OpenQA.Selenite.Interfaces
{
    public interface IAlertDialog : IBlock
    {
        string Text { get; }

        TResult Accept<TResult>() where TResult : IBlock;

        TResult Dismiss<TResult>() where TResult : IBlock;

        IAlertDialog EnterText(string text);
    }
}