using EventApi.Models.Events;

namespace EventApi.Services.Events
{
    public interface IEventsRetrievingService
    {
        Task<Event> GetEvent(Guid id);

        Task<IEnumerable<EventExtended>> GetEvents(EventsFilter filter);
    }
}
