using System;

namespace SRP
{
    public class User
    {
        private string _name;

        public User(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return this._name;
        }

        public void SetName(string newName, IUserStore users)
        {
            var userExists = users.FindUserByName(newName) != null;
            
            if (userExists)
            {
                throw new Exception($"The name {newName} is already taken");
            }

            this._name = newName;
        }
    }
}
