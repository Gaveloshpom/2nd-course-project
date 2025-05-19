using System;
using System.Collections.Generic;

namespace Course_Project.Models
{
    public class Admin : User
    {
        //public override bool Authorize(string email, string password)
        //{
        //    return true; // Заглушка
        //}

        //public override void EditProfile(string newName, string newSurname)
        //{
        //    Name = newName;
        //    Surname = newSurname;
        //}

        public List<Guid> CompletedCourses { get; set; } = new List<Guid>();
        public List<Guid> EnrolledCourses { get; set; } = new List<Guid>();

        public bool EnrollToCourse(Course course)
        {
            if (course == null || EnrolledCourses.Contains(course.Id))
                return false;

            EnrolledCourses.Add(course.Id);
            return true;
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

