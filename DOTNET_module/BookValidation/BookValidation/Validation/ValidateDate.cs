using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookValidation.Validation
{
    public class ValidateDate
    {
        private string _pattern = "^(?:(?:\\d{2}(?:\\.|/)\\d{2}(?:\\.|/)\\d{4})|\\d{4})$";

        public bool IsValidDate(ref string inputString)
        {
            Regex regex = new Regex(_pattern);
            if (inputString.Length == 4)
            {
                inputString = inputString.Insert(0, "01.01.");
            }

            return regex.Match(inputString).Success && DateTime.TryParse(inputString, out var date);
        }
    }
}
