using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Models
{
    public class CourseReview
    {
        public string UserEmail { get; set; }
        public string ReviewText { get; set; }
        public string Date { get; set; } // dd.MM.yyyy
    }


}
