namespace Course_Project.Models
{
    public class Author : RegisteredUser
    {
        public bool CreateCourse(string title, string description)
        {
            return true; // Заглушка
        }

        public bool EditCourse(Course course, string newTitle, string newDescription)
        {
            return true; // Заглушка
        }

        public bool AddLecture(Course course, Lecture lecture)
        {
            return true; // Заглушка
        }

        public bool AddPractice(Course course, Practice practice)
        {
            return true; // Заглушка
        }

        public bool DeleteCourse(Course course)
        {
            return true; // Заглушка
        }

        public bool AddCoAuthor(Course course, Author coAuthor)
        {
            return true; // Заглушка
        }
    }
}

