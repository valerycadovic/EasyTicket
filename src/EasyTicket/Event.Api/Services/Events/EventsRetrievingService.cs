using CommonLibrary.DataAccess;
using CommonLibrary.Exceptions;
using CommonLibrary.Models.Events;
using CommonLibrary.Models.Venues;
using CommonLibrary.Services.Venues;
using CommonLibrary.Views;

namespace CommonLibrary.Services.Events
{
    public class EventsRetrievingService : IEventsRetrievingService
    {
        private readonly IRepository<Event, EventsFilter> _eventsRepository;
        private readonly IVenuesRetrievingService _venuesRetrievingService;

        public EventsRetrievingService(
            IRepository<Event, EventsFilter> eventsRepository,
            IVenuesRetrievingService venuesRetrievingService)
        {
            _eventsRepository = eventsRepository;
            _venuesRetrievingService = venuesRetrievingService;
        }

        public async Task<Event> GetEvent(Guid id)
        {
            Event? @event = await _eventsRepository.GetById(id);

            if (@event is null)
            {
                throw new EntityNotFoundException(typeof(Event), id);
            }

            return @event;
        }

        public async Task<IEnumerable<EventExtended>> GetEvents(EventsFilter filter)
        {
            IEnumerable<Event> events = await _eventsRepository.Get(filter);
            IEnumerable<Venue> venues = await _venuesRetrievingService
                .GetVenues(events.Select(e => e.VenueId).ToList());
            HashSet<Venue> venuesSet = venues.ToHashSet();

            return events.Join(venuesSet, e => e.VenueId, v => v.Id, (e, v) => e.ToView(v));
        }
    }
}
