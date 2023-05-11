using EventApi.Models.Events;

namespace EventApi.Services.Events
{
    public interface IEventsModifyingService
    {
        Task AddEvent(Event @event);

        Task UpdateEventStatus(Guid eventId, EventStatus eventStatus);

        Task UpdateEvent(Event @event);

        Task DeleteEvent(Guid eventId);
    }
}
