using Newtonsoft.Json;

namespace School.Api.Event.Model
{
    public class EventTypeDto
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}