using System;
using System.Net.Mail;

namespace ScienceArchive.Core.Domain.Utils
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
            return MailAddress.TryCreate(value, out var mailAddress);
        }
    }
}

