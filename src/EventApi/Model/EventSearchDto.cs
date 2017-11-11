namespace School.Api.Event.Model
{
    public class EventSearchDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;

        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;

        public string LocationVenue { get; set; } = string.Empty;
    }
}