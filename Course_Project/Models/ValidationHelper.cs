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

        public static string ValidateCourseTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return "Назва обов'язкова!";

            if (title.Length < 1 || title.Length > 30)
                return "Назва має містити від 1 до 30 символів!";

            return null;
        }

        public static string ValidateCourseDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return "Опис обов'язковий!";

            if (description.Length < 5 || description.Length > 200)
                return "Опис має містити від 5 до 200 символів!";

            return null;
        }

        public static string ValidateLectureTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return "Заголовок лекції обов'язковий!";

            if (title.Length < 5 || title.Length > 30)
                return "Заголовок лекції має містити від 5 до 30 символів!";

            return null;
        }

        public static string ValidateLectureText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "Текст лекції обов'язковий!";

            if (text.Length < 50 || text.Length > 400)
                return "Текст лекції має містити від 50 до 400 символів!";

            return null;
        }

        public static string ValidatePracticeTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return "Заголовок практичного заняття обов'язковий!";

            if (title.Length < 5 || title.Length > 30)
                return "Заголовок практичного заняття має містити від 5 до 30 символів!";

            return null;
        }

        public static string ValidatePracticeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "Формулювання завдання практичного заняття обов'язкове!";

            if (text.Length < 5 || text.Length > 200)
                return "Формулювання до завдання практичного заняття має містити від 5 до 200 символів!";

            return null;
        }

        public static string ValidatePracticeAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
                return "Відповідь до завдання практичного заняття обов'язкова!";

            if (answer.Length < 1 || answer.Length > 50)
                return "Відповідь до завдання практичного заняття має містити від 1 до 50 символів!";

            return null;
        }
    }
}
