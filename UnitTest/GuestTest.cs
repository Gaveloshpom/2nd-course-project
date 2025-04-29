using Microsoft.VisualStudio.TestTools.UnitTesting;
using Course_Project.Models;
using System;

namespace Course_Project.Test
{
    [TestClass]
    public class GuestTest
    {
        [TestMethod]
        [DataRow("test@example.com", "Example1234", "Andrii", "Potuzniy", "User")]
        public void Registration_Valid(string email, string password, string name, string surname, string role)
        {
            var guest = new Models.Guest();
            bool result = guest.Register(email, password, name, surname, role);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("@example.com", "Example1234", "Andrii", "Potuzniy", "User")]
        [ExpectedException(typeof(Exception), "Некоректний ввід пошти!")]
        public void Registration_Email_InValid(string email, string password, string name, string surname, string role)
        {
            var guest = new Models.Guest();
            bool result = guest.Register(email, password, name, surname, role);
        }

        [TestMethod]
        [DataRow("test@example.com", "1234", "Andrii", "Potuzniy", "User")]
        [ExpectedException(typeof(Exception), "Некоректний ввід паролю!")]
        public void Registration_Password_InValid(string email, string password, string name, string surname, string role)
        {
            var guest = new Models.Guest();
            bool result = guest.Register(email, password, name, surname, role);
        }

        [TestMethod]
        [DataRow("test@example.com", "Example1234", "A", "Potuzniy", "User")]
        [DataRow("test@example.com", "Example1234", "Andriiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii", "Potuzniy", "User")]
        [ExpectedException(typeof(Exception), "Некоректний ввід імені!")]
        public void Registration_Name_InValid(string email, string password, string name, string surname, string role)
        {
            var guest = new Models.Guest();
            bool result = guest.Register(email, password, name, surname, role);
        }

        [TestMethod]
        [DataRow("test@example.com", "Example1234", "Andrii", "P", "User")]
        [DataRow("test@example.com", "Example1234", "Andrii", "Paaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "User")]
        [ExpectedException(typeof(Exception), "Некоректний ввід прізвища!")]
        public void Registration_Surname_InValid(string email, string password, string name, string surname, string role)
        {
            var guest = new Models.Guest();
            bool result = guest.Register(email, password, name, surname, role);
        }
    }
}

