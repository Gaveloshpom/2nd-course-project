using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Models
{
    public interface ICourseManageable
    {
        bool CreateCourse(string title, string description);
        bool DeleteCourse(Course course);
        bool AddLecture(Course course, Lecture lecture);
        bool AddPractice(Course course, Practice practice);
    }
}

