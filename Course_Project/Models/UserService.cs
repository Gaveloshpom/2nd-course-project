using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Course_Project.Models
{
    public static class UserService
    {
        private static readonly string FilePath = "users.json";

        public static List<RegisteredUser> LoadUsers()
        {
            if (!File.Exists(FilePath))
                return new List<RegisteredUser>();

            var json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<RegisteredUser>>(json);
        }

        public static void SaveUsers(List<RegisteredUser> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
