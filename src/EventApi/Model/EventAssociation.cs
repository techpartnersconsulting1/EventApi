using System.Collections.Generic;
using Newtonsoft.Json;

namespace School.Api.Event.Model
{
    public class EventAssociation
    {
        [JsonProperty("classIds")] public List<string> ClassIds = new List<string>();

        [JsonProperty("gradeIds")] public List<string> GradeIds = new List<string>();

        [JsonProperty("schoolDistrictIds")] public List<string> SchoolDistrictIds = new List<string>();

        [JsonProperty("schoolIds")] public List<string> SchoolIds = new List<string>();

        [JsonProperty("eventType")]
        public EventType EventType { get; set; } = new EventType();
    }
}