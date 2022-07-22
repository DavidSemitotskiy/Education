using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class UserNavigation
    {

        public List<string> NavigationUser { get; } = new List<string>();

        public string CurrentFile { get; set; } = "";

        public string CurrentDirectory { get; set; } = Directory.GetCurrentDirectory();
    }
}
