using System;
using Course_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class AuthorTests
    {
        [TestMethod]
        public void EnrollToCourse_AddsCourse()
        {
            var user = new Author();
            var course = new Course();

            var result = user.EnrollToCourse(course);

            Assert.IsTrue(result);
            Assert.IsTrue(user.EnrolledCourses.Contains(course.Id));
        }

        [TestMethod]
        public void EnrollToCourse_DuplicateCourse_Fails()
        {
            var user = new Author();
            var course = new Course();
            user.EnrollToCourse(course);

            var result = user.EnrollToCourse(course);

            Assert.IsFalse(result);
        }
    }
}
