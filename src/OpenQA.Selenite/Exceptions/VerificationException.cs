using System;

namespace OpenQA.Selenite.Exceptions
{
    /// <summary>
    ///     Исключение верификации поведения
    /// </summary>
    public class VerificationException
        : Exception
    {
        /// <summary>
        ///     Новое исключение <see cref="VerificationException" /> с сообщением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        public VerificationException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Новое исключение <see cref="VerificationException" /> с сообщением и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="innerException">
        ///     Породившее исключение или null
        /// </param>
        public VerificationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}