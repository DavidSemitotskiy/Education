using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class UserNavigationRepository : IUserNavigationRepository
    {
        public void SaveNavigation(UserNavigation userNavigation)
        {
            string serializeUserNavigationHistory = JsonConvert.SerializeObject(userNavigation);
            using (StreamWriter file = new StreamWriter("NavigationHistory.json", true))
            {
                file.Write(serializeUserNavigationHistory);
            }
        }
    }
}
