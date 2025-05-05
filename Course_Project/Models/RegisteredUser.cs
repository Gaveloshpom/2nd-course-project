using System;
using System.Collections.Generic;

namespace Course_Project.Models
{
    public class RegisteredUser : User, ICourseViewable
    {
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();

        public bool EnrollToCourse(Course course)
        {
            if (course == null || EnrolledCourses.Contains(course))
                return false;

            EnrolledCourses.Add(course);
            return true;
        }

        public IEnumerable<Course> ViewAllCourses()
        {
            return CourseStorage.Courses;
        }

        public IEnumerable<Lecture> ViewLectures(Course course)
        {
            return course?.LectureList ?? new List<Lecture>();
        }

        public IEnumerable<Practice> ViewPractices(Course course)
        {
            return course?.PracticeList ?? new List<Practice>();
        }

        public override bool Authorize(string email, string password)
        {
            throw new NotImplementedException();
        }

        public override void EditProfile(string newName, string newSurname)
        {
            throw new NotImplementedException();
        }
    }
}

