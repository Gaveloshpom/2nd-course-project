using Newtonsoft.Json;


namespace Course_Project.Models
{
    public class Lecture
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
    }
}


