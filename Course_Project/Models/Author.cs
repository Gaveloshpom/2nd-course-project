using System.Linq;

namespace Course_Project.Models
{
    public class Author : RegisteredUser, ICourseManageable
    {
        public bool CreateCourse(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
                return false;

            var newCourse = new Course
            {
                Title = title,
                Description = description
            };

            newCourse.AuthorEmailList.Add(this.Email);
            CourseStorage.Courses.Add(newCourse);

            return true;
        }

        public bool DeleteCourse(Course course)
        {
            if (course == null)
                return false;

            if (!CourseStorage.Courses.Contains(course))
                return false;

            return CourseStorage.Courses.Remove(course);
        }

        public bool AddLecture(Course course, Lecture lecture)
        {
            if (course == null || lecture == null)
                return false;

            course.ContentBlocks.Add(new ContentBlock { Type = "Лекція", LectureData = lecture });
            return true;
        }

        public bool AddPractice(Course course, Practice practice)
        {
            if (course == null || practice == null)
                return false;

            course.ContentBlocks.Add(new ContentBlock { Type = "Практика", PracticeData = practice });
            return true;
        }
    }
}


