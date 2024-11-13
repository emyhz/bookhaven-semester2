using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.StringManipulation
{
    public class UserFormatter
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            string lowercased = input.ToLower();
            string capitalized = char.ToUpper(lowercased[0]) + lowercased.Substring(1);

            return capitalized;
        }
    }
}
