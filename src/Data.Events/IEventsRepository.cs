namespace Data.Events
{
    public interface IEventsRepository
    {
        EventDtoList Search(SearchDto dto);
        string Save(EventDto dto);
    }
}