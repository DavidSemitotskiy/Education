using OCP.Domain;
using System.Collections.Generic;

namespace OCP
{
    public interface IUserStore
    {
        IEnumerable<User> Users { get; }
    }

    public class UserStore : IUserStore
    {
        public IEnumerable<User> Users { get; } = new List<User>();
    }
}
