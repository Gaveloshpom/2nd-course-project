using Course_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticeTests
{
    [TestClass]
    public class PracticeTests
    {
        [TestMethod]
        public void Practice_SetProperties_Correctly()
        {
            var practice = new Practice
            {
                Title = "Обчисліть суму",
                Question = "5 + 7 = ?",
                Answer = "12",
                Likes = 1,
                Dislikes = 0
            };

            Assert.AreEqual("Обчисліть суму", practice.Title);
            Assert.AreEqual("5 + 7 = ?", practice.Question);
            Assert.AreEqual("12", practice.Answer);
            Assert.AreEqual(1, practice.Likes);
            Assert.AreEqual(0, practice.Dislikes);
        }

        [TestMethod]
        public void Practice_EmptyConstructor_InitializesCorrectly()
        {
            var practice = new Practice();
            Assert.IsNull(practice.Title);
            Assert.AreEqual(0, practice.Likes);
        }
    }
}