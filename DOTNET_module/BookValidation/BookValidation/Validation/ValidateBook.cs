using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidation.Validation
{
    public static class ValidateBook
    {
        private static string _pattern = "^([A-Za-zA-Яа-яІ-і .,\']+) - ([A-Za-zA-Яа-яІ-і .,:()\'\"]+), (\\d{1,4}) \\(((?:\\d{2}(?:\\.|/)\\d{2}(?:\\.|/)\\d{4}|\\d{4}))\\)\\.(pdf|doc|txt)";
    }
}
