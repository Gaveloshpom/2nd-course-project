using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Models
{
    public static class UserStorage
    {
        public static List<RegisteredUser> Users { get; set; } = new List<RegisteredUser>();

        private static readonly string FilePath = "users.json";

        public static void Load()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                Users = JsonConvert.DeserializeObject<List<RegisteredUser>>(json) ?? new List<RegisteredUser>();
            }
        }

        public static void Save()
        {
            var json = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static RegisteredUser FindUser(string email) =>
            Users.FirstOrDefault(u => u.Email == email);
    }
}
