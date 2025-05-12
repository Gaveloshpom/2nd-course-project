using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Models
{
    public interface ICourseViewable
    {
        IEnumerable<Course> ViewAllCourses();
        IEnumerable<Lecture> ViewLectures(Course course);
        IEnumerable<Practice> ViewPractices(Course course);
    }
}
