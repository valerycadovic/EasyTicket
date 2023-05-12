using CommonLibrary.DataAccess;
using CommonLibrary.Models.Events;

namespace CommonLibrary.Services.Events
{
    public sealed class EventsModifyingService : IEventsModifyingService
    {
        private readonly IRepository<Event, EventsFilter> _eventsRepository;
        private readonly IEventsRetrievingService _eventsRetrievingService;

        public EventsModifyingService(
            IRepository<Event, EventsFilter> eventsRepository,
            IEventsRetrievingService eventsRetrievingService)
        {
            _eventsRepository = eventsRepository;
            _eventsRetrievingService = eventsRetrievingService;
        }

        public async Task AddEvent(Event @event)
        {
            await _eventsRepository.Add(@event);
        }

        public async Task DeleteEvent(Guid eventId)
        {
            await _eventsRepository.Delete(eventId);
        }

        public async Task UpdateEventStatus(Guid eventId, EventStatus eventStatus)
        {
            Event @event = await _eventsRetrievingService.GetEvent(eventId);

            @event = @event with { Status = eventStatus };

            await UpdateEvent(@event);
        }

        public async Task UpdateEvent(Event @event)
        {
            await _eventsRepository.Update(@event);
        }
    }
}
