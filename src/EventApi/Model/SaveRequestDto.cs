using Data.Events;

namespace School.Api.Event.Model
{
    public class SaveRequestDto
    {
        public EventDto EventDto { get; set; } = new EventDto();
    }
}