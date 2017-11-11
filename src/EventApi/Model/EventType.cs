using Newtonsoft.Json;

namespace School.Api.Event.Model
{
    public class EventType
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        public string NotificationTemplate { get; set; } = string.Empty;
        public string CreateDate { get; set; } = string.Empty;
        public string CreateUser { get; set; } = string.Empty;
        public string UpdateUser { get; set; } = string.Empty;
        public string UpdateDate { get; set; } = string.Empty;
        public string IsActive { get; set; } = string.Empty;
    }
}