using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Course_Project.Models
{
    public static class ValidationHelper
    {
        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return "Email обов'язковий!";

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Невірний формат email!";

            return null;
        }

        public static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Ім'я користувача обов'язкове!";

            if (name.Length < 2 || name.Length > 20)
                return "Ім'я користувача має містити від 2 до 20 символів!";

            if (!Regex.IsMatch(name, @"^[A-Za-z]+$"))
                return "Ім’я має містити лише латинські літери";

            return null;
        }

        public static string ValidateSurname(string surname)
        {
            if (string.IsNullOrWhiteSpace(surname))
                return "Прізвище користувача обов'язкове!";

            if (surname.Length < 2 || surname.Length > 20)
                return "Прізвище користувача має містити від 2 до 20 символів!";

            if (!Regex.IsMatch(surname, @"^[A-Za-z]+$"))
                return "Прізвище має містити лише латинські літери";

            return null;
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "Пароль обов'язковий";

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,20}$"))
                return "Пароль має містити 1 велику, 1 малу літеру, 1 цифру, довжину 8–20 символів, лише латиниця!";

            return null;
        }
    }
}
