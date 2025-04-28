using Newtonsoft.Json;

namespace Course_Project.Models
{
    [JsonObject]
    public class Practice : IContentItem
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string TaskText { get; set; }

        [JsonProperty]
        public string CorrectAnswer { get; set; }

        public string GetTitle() => Title;

        public string GetContent() => TaskText;
    }
}

