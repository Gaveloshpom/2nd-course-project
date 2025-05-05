using Newtonsoft.Json;

namespace Course_Project.Models
{
    public class Lecture : IContentItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

}

