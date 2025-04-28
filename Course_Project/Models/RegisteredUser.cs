using System.Collections.Generic;

namespace Course_Project.Models
{
    public class RegisteredUser : User
    {
        public override bool Authorize(string email, string password)
        {
            return true; // TODO: Реалізувати логіку авторизації
        }

        public override void EditProfile(string newName, string newSurname)
        {
            Name = newName;
            Surname = newSurname;
        }

        public List<Course> ViewCourses() => new List<Course>(); // Заглушка

        public bool RegisterToCourse(Course course) => true; // Заглушка

        public bool RateCourse(Course course, int rating) => rating >= 1 && rating <= 5; // Заглушка

        public bool LeaveReview(Course course, string reviewText) => reviewText.Length >= 5 && reviewText.Length <= 200; // Заглушка
    }
}
