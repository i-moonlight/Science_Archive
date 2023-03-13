using System;
using System.Net.Mail;

namespace ScienceArchive.Core.Utils
{
    /// <summary>
    /// Strings validation helper
    /// </summary>
    public static class StringValidator
    {
        /// <summary>
        /// Is string email address
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>True if email, otherwise, false</returns>
        public static bool IsEmail(string value)
        {
            var validated = MailAddress.TryCreate(value, out var mailAddress);
            return validated;
        }

        /// <summary>
        /// Is string null or contains only whitespace characters
        /// </summary>
        /// <param name="value">Value to be checked</param>
        /// <returns>
        /// True if null or contains
        /// only whitespaces, otherwise, false
        /// </returns>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
    }
}

