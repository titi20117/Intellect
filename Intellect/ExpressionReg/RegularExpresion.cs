using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressionReg
{
    public class RegularExpresion
    {
        public string GetBasisFromWord(string expression, string condition)
        {
            Regex regex = new Regex(condition);
            MatchCollection matches = regex.Matches(expression);
            string result = expression;

            if (matches.Count > 0)
            {
                string value = "";
                foreach (Match match in matches)
                {
                    value = match.Value;
                }
                result = result.Replace(value, "");
            }
            return result;
        }

        /// <summary>
        /// заменяем предложение с определенного условие(pattern)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        public string ReplaceSentence(string input, string pattern, string replacement)
        {
            Regex regex = new Regex(pattern);
            string result = regex.Replace(input, replacement);

            return result;
        }
    }
}
