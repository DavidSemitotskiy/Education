using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookValidation.Validation
{
    public class ValidateBook
    {
        private string _pattern = "^([A-Za-zA-Яа-яІ-і .,\']+) - ([A-Za-zA-Яа-яІ-і .,:()\'\"]+), (\\d{1,4}) \\((?:((?:\\d{2}\\.\\d{2}\\.\\d{4})|(?:\\d{2}/\\d{2}/\\d{4})|\\d{4}))\\)\\.(pdf|doc|txt)";

        public Match IsValidInputString(string inputtedString)
        {
            Regex regex = new Regex(_pattern);
            return regex.Match(inputtedString);
        }
    }
}
