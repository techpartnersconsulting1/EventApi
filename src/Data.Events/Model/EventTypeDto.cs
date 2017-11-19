using Newtonsoft.Json;

namespace Data.Events
{
    public class EventTypeDto
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}