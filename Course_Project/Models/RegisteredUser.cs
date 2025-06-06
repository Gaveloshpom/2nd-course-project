﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Course_Project.Models
{
    public class RegisteredUser : User, ICourseViewable
    {
        public List<Guid> CompletedCourses { get; set; } = new List<Guid>();
        public List<Guid> EnrolledCourses { get; set; } = new List<Guid>();

        public bool EnrollToCourse(Course course)
        {
            if (course == null || EnrolledCourses.Contains(course.Id))
                return false;

            EnrolledCourses.Add(course.Id);
            return true;
        }

        public IEnumerable<Course> ViewAllCourses()
        {
            return CourseStorage.Courses;
        }

        public IEnumerable<Lecture> ViewLectures(Course course)
        {
            return course?.ContentBlocks
                .Where(c => c.Type == "Лекція")
                .Select(c => c.LectureData) ?? new List<Lecture>();
        }

        public IEnumerable<Practice> ViewPractices(Course course)
        {
            return course?.ContentBlocks
                .Where(c => c.Type == "Практика")
                .Select(c => c.PracticeData) ?? new List<Practice>();
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

