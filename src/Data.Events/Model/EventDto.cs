using System.Collections.Generic;
using Newtonsoft.Json;

namespace Data.Events
{
    public class EventDto
    {
        [JsonProperty("association")]
        public EventAssociationDto Association = new EventAssociationDto();

        //public EventType EventType { get; set; } = new EventType();

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("eventActionType")]
        public string eventActionType { get; set; } = string.Empty;
        

        [JsonProperty("locationVenue")]
        public string LocationVenue { get; set; } = string.Empty;

        [JsonProperty("needStudentEnrollment")]
        public string NeedStudentEnrollment { get; set; } = string.Empty;

        public string IsActive { get; set; } = string.Empty;
        public string CreateDate { get; set; } = string.Empty;
        public string CreateUser { get; set; } = string.Empty;
        public string UpdateUser { get; set; } = string.Empty;
        public string UpdateDate { get; set; } = string.Empty;

        public OccuranceTypeDto OccuranceType { get; set; } = new OccuranceTypeDto();

        [JsonProperty("schedules")]
        public IList<ScheduleDto> Schedules { get; set; } = new List<ScheduleDto>();
    }
}