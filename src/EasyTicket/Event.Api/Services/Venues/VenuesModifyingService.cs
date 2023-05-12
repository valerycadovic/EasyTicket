using CommonLibrary.DataAccess;
using CommonLibrary.DataAccess.Venues;
using CommonLibrary.Models.Venues;

namespace CommonLibrary.Services.Venues
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
