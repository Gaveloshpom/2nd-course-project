using Course_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace UnitTest
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Rating_WithRatings_CalculatesAverage()
        {
            var course = new Course { Ratings = new List<int> { 4, 5, 5 } };
            Assert.AreEqual(4.7, course.Rating);
        }

        [TestMethod]
        public void Rating_NoRatings_ReturnsZero()
        {
            var course = new Course();
            Assert.AreEqual(0.0, course.Rating);
        }
    }
}
