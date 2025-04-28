using System;

namespace Course_Project.Models
{
    public class Guest : User
    {
        public override bool Authorize(string email, string password)
        {
            return false; // Guests don't authorize
        }

        public override void EditProfile(string newName, string newSurname)
        {
            // Guest does not edit profile
        }

        public bool Register(string email, string password, string name, string surname, DateTime dateOfBirth)
        {
            // TODO: Реалізувати реєстрацію
            return true;
        }
    }
}


