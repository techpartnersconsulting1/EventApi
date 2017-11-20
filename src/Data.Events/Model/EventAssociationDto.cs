using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data.Events
{
    public class EventAssociationDto
    {
        [JsonProperty("classIds")] public IList<string> ClassIds = new List<string>();

        [JsonProperty("gradeIds")] public IList<string> GradeIds = new List<string>();

        [JsonProperty("schoolDistrictIds")] public IList<string> SchoolDistrictIds = new List<string>();

        [JsonProperty("schoolIds")] public IList<string> SchoolIds = new List<string>();

        [JsonProperty("eventType")]
        public EventTypeDto EventType { get; set; } = new EventTypeDto();
    }
}