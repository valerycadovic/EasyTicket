using EventApi.Models.Venues;

namespace EventApi.Services.Venues
{
    public interface IVenuesModifyingService
    {
        Task AddVenue(Venue venue);

        Task UpdateVenue(Venue venue);

        Task DeleteVenue(Guid venueId);
    }
}
