using Newtonsoft.Json;

namespace Course_Project.Models
{
    public class Practice
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }
}

