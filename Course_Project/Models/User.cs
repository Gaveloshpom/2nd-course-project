using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Course_Project.Models
{
    public abstract class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        // Можна додати авторизаційні методи, пізніше
    }
}

