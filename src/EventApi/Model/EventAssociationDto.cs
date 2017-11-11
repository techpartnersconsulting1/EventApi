using System.Collections.Generic;
using Newtonsoft.Json;

namespace School.Api.Event.Model
{
    public class EventAssociationDto
    {
        [JsonProperty("classIds")]
        public List<string> ClassIds = new List<string>();

        [JsonProperty("gradeIds")]
        public List<string> GradeIds = new List<string>();

        [JsonProperty("schoolDistrictIds")]
        public List<string> SchoolDistrictIds = new List<string>();

        [JsonProperty("schoolIds")]
        public List<string> SchoolIds = new List<string>();

        [JsonProperty("eventType")]
        public EventTypeDto EventType { get; set; } = new EventTypeDto();
    }
}