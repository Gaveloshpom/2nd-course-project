using System;
using Course_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class ContentBlockTests
    {
        [TestMethod]
        public void Title_ReturnsLectureTitle()
        {
            var block = new ContentBlock
            {
                Type = "Лекція",
                LectureData = new Lecture { Title = "Тестова лекція" }
            };

            Assert.AreEqual("Тестова лекція", block.Title);
        }

        [TestMethod]
        public void Title_ReturnsPracticeTitle()
        {
            var block = new ContentBlock
            {
                Type = "Практика",
                PracticeData = new Practice { Title = "Тестова практика" }
            };

            Assert.AreEqual("Тестова практика", block.Title);
        }
    }
}
