namespace OpenQA.Selenite.Setup
{
    /// <summary>
    /// Session settings
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Where to save captured screenshots
        /// </summary>
        string ScreenCapturePath { get; }

        /// <summary>
        /// Flag to make a screenshot on failure
        /// </summary>
        bool CaptureScreenOnVerificationFailure { get; }
    }
}