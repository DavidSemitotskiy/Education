using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRP
{
    public class UserStore : IUserStore
    {
        public UserStore(List<User> users)
        {
            Users = users;
        }

        public List<User> Users { get; private set; }

        public User FindUserByName(string name)
        {
            return Users.FirstOrDefault(user => user.GetName() == name);
        }
    }
}
