using Newtonsoft.Json;

namespace Course_Project.Models
{
    [JsonObject]
    public class Practice : IContentItem
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Content { get; set; }

        [JsonProperty]
        public string CorrectAnswer { get; set; }
    }
}

