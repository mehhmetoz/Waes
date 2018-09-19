using System;

namespace Waes.Api.Helpers
{
    public class Decoder
    {
        /// <summary>
        /// Decodes a Base 64 encoded string back to string and removes "\", "\r" and "\n" characters
        /// </summary>
        /// <param name="input">Base 64 encoded string</param>
        /// <returns>Decoded string</returns>
        public static string Decode(string input)
        {
            if (String.IsNullOrWhiteSpace(input)) { throw new ArgumentNullException(nameof(input), "Please provide a valid input"); }

            var byteArray = Convert.FromBase64String(input);
            var stringified = System.Text.Encoding.Default.GetString(byteArray);

            return stringified.Replace("\n", "").Replace("\r", "").Replace(@"\", "");
        }
    }
}