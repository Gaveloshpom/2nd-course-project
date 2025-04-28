namespace Course_Project.Models
{
    public class Admin : User
    {
        public override bool Authorize(string email, string password)
        {
            return true; // Заглушка
        }

        public override void EditProfile(string newName, string newSurname)
        {
            Name = newName;
            Surname = newSurname;
        }

        public bool ApproveCourse(Course course)
        {
            return true; // Заглушка
        }

        public bool FreezeCourse(Course course, string reason)
        {
            return !string.IsNullOrWhiteSpace(reason); // Заглушка
        }

        public bool DeleteCourse(Course course, string reason)
        {
            return !string.IsNullOrWhiteSpace(reason); // Заглушка
        }
    }
}

