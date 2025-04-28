using Newtonsoft.Json;

namespace Course_Project.Models
{
    [JsonObject]
    public class Lecture : IContentItem
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Content { get; set; }

        public string GetTitle() => Title;

        public string GetContent() => Content;
    }
}

