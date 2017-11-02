using System;
using System.Collections.Generic;
using System.Text;

namespace Develothink.BlogProvider.Extensions
{
    public static class StringExtensionMethods
    {
        public static string ConvertDashToPascalCase(this string input)
        {
            var sb = new StringBuilder();
            var caseFlag = true;

            foreach (var c in input)
            {
                if (c == '-')
                {
                    caseFlag = true;
                }
                else if (caseFlag)
                {
                    sb.Append(char.ToUpper(c));
                    caseFlag = false;
                }
                else
                {
                    sb.Append(char.ToLower(c));
                }
            }
            return sb.ToString();
        }

        public static string[] ToSearchableStringArray(this string input)
        {
            return input.ToLower().Split(" ");
        }
    }
}
