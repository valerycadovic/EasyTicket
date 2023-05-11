using EventApi.DataAccess;
using EventApi.DataAccess.Venues;
using EventApi.Models.Venues;

namespace EventApi.Services.Venues
{
    public class VenuesModifyingService : IVenuesModifyingService
    {
        private readonly IVenuesRepository _venuesRepository;

        public VenuesModifyingService(IVenuesRepository venuesRepository)
        {
            _venuesRepository = venuesRepository;
        }

        public async Task AddVenue(Venue venue)
        {
            await _venuesRepository.Add(venue);
        }

        public async Task DeleteVenue(Guid venueId)
        {
            await _venuesRepository.Delete(venueId);
        }

        public async Task UpdateVenue(Venue venue)
        {
            await _venuesRepository.Update(venue);
        }
    }
}
