using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Course_Project.Models
{
    public static class CourseService
    {
        private static readonly string filePath = "courses.json";

        /// <summary>
        /// Завантажує всі курси з JSON-файлу
        /// </summary>
        public static List<Course> LoadCourses()
        {
            if (!File.Exists(filePath))
                return new List<Course>();

            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Course>>(json) ?? new List<Course>();
        }

        /// <summary>
        /// Зберігає вказаний список курсів у файл
        /// </summary>
        public static void SaveCourses(List<Course> courses)
        {
            var json = JsonConvert.SerializeObject(courses, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Додає новий курс і зберігає
        /// </summary>
        public static void AddCourse(Course course)
        {
            var courses = LoadCourses();
            courses.Add(course);
            SaveCourses(courses);
        }

        /// <summary>
        /// Оновлює існуючий курс (за Title + Email автора)
        /// </summary>
        public static void UpdateCourse(Course updated)
        {
            var courses = LoadCourses();

            var course = courses.FirstOrDefault(c =>
                c.Title == updated.Title &&
                c.AuthorEmailList != null &&
                c.AuthorEmailList.Contains(updated.AuthorEmailList.FirstOrDefault())); // перший автор як "головний"

            if (course != null)
            {
                course.Description = updated.Description;
                course.Status = updated.Status;
                course.LectureList = updated.LectureList;
                course.PracticeList = updated.PracticeList;
                course.AuthorEmailList = updated.AuthorEmailList;

                SaveCourses(courses);
            }
        }

        /// <summary>
        /// Видаляє курс за Title + будь-який email автора
        /// </summary>
        public static void DeleteCourse(Course courseToDelete)
        {
            var courses = LoadCourses();

            var updated = courses.Where(c =>
                !(c.Title == courseToDelete.Title &&
                  c.AuthorEmailList != null &&
                  c.AuthorEmailList.Intersect(courseToDelete.AuthorEmailList).Any())
            ).ToList();

            SaveCourses(updated);
        }

        /// <summary>
        /// Повертає курси певного автора
        /// </summary>
        public static List<Course> GetCoursesByAuthor(string authorEmail)
        {
            var courses = LoadCourses();
            return courses.Where(c =>
                c.AuthorEmailList != null &&
                c.AuthorEmailList.Contains(authorEmail)).ToList();
        }

        public static void RateCourse(Course course, int score)
        {
            if (score < 1 || score > 5) return;

            if (course.Ratings == null)
                course.Ratings = new List<int>();
            course.Ratings.Add(score);
            UpdateCourse(course);
        }
    }
}

