using Newtonsoft.Json;
using System;
using System.IO;

namespace SRP
{
    public class User
    {
        private IUserStore store;

        public User(IUserStore store)
        {
            this.store = store;
        }

        private string name;

        public string Name
        {
            get => this.name;
            set
            {
                var userExists = this.store.FindUserByName(value) != null;

                if (userExists)
                {
                    throw new Exception($"The name {value} is already taken");
                }

                this.name = value;
            }
        }

        public void SaveToFile(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
        }
    }
}
