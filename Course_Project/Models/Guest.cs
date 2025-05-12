using System;

namespace Course_Project.Models
{
    public class Guest : User
    {
        public override bool Authorize(string email, string password)
        {
            throw new NotImplementedException(); //can`t authorize
        }

        public override void EditProfile(string newName, string newSurname)
        {
            throw new NotImplementedException(); //can`t edit profile
        }

        public bool Register(string email, string password, string name, string surname, string role)
        {
            // TODO: Реалізувати реєстрацію
            return true;
        }
    }
}


