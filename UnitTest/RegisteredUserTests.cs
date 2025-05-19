using Course_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class RegisteredUserTests
    {
        [TestMethod]
        public void EnrollToCourse_AddsCourse()
        {
            var user = new RegisteredUser();
            var course = new Course();

            var result = user.EnrollToCourse(course);

            Assert.IsTrue(result);
            Assert.IsTrue(user.EnrolledCourses.Contains(course.Id));
        }

        [TestMethod]
        public void EnrollToCourse_DuplicateCourse_Fails()
        {
            var user = new RegisteredUser();
            var course = new Course();
            user.EnrollToCourse(course);

            var result = user.EnrollToCourse(course);

            Assert.IsFalse(result);
        }
    }
}
