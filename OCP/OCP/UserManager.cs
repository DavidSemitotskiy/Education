using OCP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OCP
{
    public class UserManager
    {
        private readonly IUserStore userStore = new UserStore();

        public User[] GetAdmins() => this.userStore.Users.Where(u => u.Role == Roles.Admin).ToArray();

        public User[] GetPremiumUsers() => this.userStore.Users.Where(u => u.IsPremiumUser && u.Subscription.IsActive).ToArray();

        public User[] GetSimpleUsers() => this.userStore.Users.Where(u => u.Role != Roles.Admin && !u.IsPremiumUser).ToArray();

        public User[] GetSimpleUsersWhosSubscriptionHasExpired() => throw new NotImplementedException();

        public User[] GetUsersCustomFilter(Func<User, bool> expression)
        {
            return this.userStore.Users.Where(expression).ToArray();
        }
    }
}
