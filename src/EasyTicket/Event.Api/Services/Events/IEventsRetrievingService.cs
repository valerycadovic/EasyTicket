using CommonLibrary.Models.Events;

namespace CommonLibrary.Services.Events
{
    public interface IEventsRetrievingService
    {
        Task<Event> GetEvent(Guid id);

        Task<IEnumerable<EventExtended>> GetEvents(EventsFilter filter);
    }
}
