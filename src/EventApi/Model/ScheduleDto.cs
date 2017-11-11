using System.Collections.Generic;
using Newtonsoft.Json;

namespace School.Api.Event.Model
{
    public class ScheduleDto
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; } = string.Empty;

        [JsonProperty("endDate")]
        public string EndDate { get; set; } = string.Empty;

        [JsonProperty("startTime")]
        public string StartTime { get; set; } = string.Empty;

        [JsonProperty("endTime")]
        public string EndTime { get; set; } = string.Empty;


        [JsonProperty("weekDays")]
        public List<string> WeekDays { get; set; } = new List<string>();
    }
}