using Course_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CourseReviewTests {
    [TestClass]
    public class CourseReviewTests
    {
        [TestMethod]
        public void CourseReview_SetProperties_Correctly()
        {
            var review = new CourseReview
            {
                UserEmail = "user@example.com",
                ReviewText = "Чудовий курс!",
                Date = DateTime.Today.ToString(),
            };

            Assert.AreEqual("user@example.com", review.UserEmail);
            Assert.AreEqual("Чудовий курс!", review.ReviewText);
            Assert.AreEqual(DateTime.Today.ToString(), review.Date);
        }

        [TestMethod]
        public void CourseReview_DefaultComment_Null()
        {
            var review = new CourseReview();
            Assert.IsNull(review.ReviewText);
        }
    }
}