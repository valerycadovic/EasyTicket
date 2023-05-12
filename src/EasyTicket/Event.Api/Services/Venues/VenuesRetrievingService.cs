using CommonLibrary.DataAccess;
using CommonLibrary.DataAccess.Venues;
using CommonLibrary.Exceptions;
using CommonLibrary.Models.Venues;

namespace CommonLibrary.Services.Venues
{
    public class VenuesRetrievingService : IVenuesRetrievingService
    {
        private readonly IVenuesRepository _venuesRepository;

        public VenuesRetrievingService(IVenuesRepository venuesRepository)
        {
            _venuesRepository = venuesRepository;
        }

        public async Task<Venue> GetVenue(Guid venueId)
        {
            Venue? venue = await _venuesRepository.GetById(venueId);

            if (venue is null)
            {
                throw new EntityNotFoundException(typeof(Venue), venueId);
            }

            return venue;
        }

        public async Task<IEnumerable<Venue>> GetVenues(VenuesFilter filter)
        {
            return await _venuesRepository.Get(filter);
        }

        public async Task<IEnumerable<Venue>> GetVenues(IReadOnlyCollection<Guid> venueIds)
        {
            return await _venuesRepository.GetVenues(venueIds);
        }
    }
}
