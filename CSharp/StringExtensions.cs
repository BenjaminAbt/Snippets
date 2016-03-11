using System;

namespace SchwabenCode.Basics
{
      public static class StringExtensions
      {
            /// <summary>
            /// Cuts a string with the given max length
            /// </summary>
            public static string WithMaxLength(this string value, int maxLength)
            {
                return value?.Substring(0, Math.Min(value.Length, maxLength));
            }
      }
}
