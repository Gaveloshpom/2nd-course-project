using Course_Project.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LectureTests
{
    [TestClass]
    public class LectureTests
    {
        [TestMethod]
        public void Lecture_SetProperties_Correctly()
        {
            var lecture = new Lecture
            {
                Title = "Вступ до C#",
                Text = "C# — це сучасна мова програмування.",
                Likes = 5,
                Dislikes = 2
            };

            Assert.AreEqual("Вступ до C#", lecture.Title);
            Assert.AreEqual("C# — це сучасна мова програмування.", lecture.Text);
            Assert.AreEqual(5, lecture.Likes);
            Assert.AreEqual(2, lecture.Dislikes);
        }

        [TestMethod]
        public void Lecture_DefaultValues_AreZero()
        {
            var lecture = new Lecture();
            Assert.AreEqual(0, lecture.Likes);
            Assert.AreEqual(0, lecture.Dislikes);
        }
    }
}