using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SRP
{
    public class FileService
    {
        public void SaveToFile(string fileName, IUserStore users)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(users));
        }
    }
}
