using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public interface IUserNavigationRepository
    {
        void SaveNavigation(UserNavigation userNavigation);
    }
}
