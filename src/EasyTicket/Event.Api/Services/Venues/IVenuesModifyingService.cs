using CommonLibrary.Models.Venues;

namespace CommonLibrary.Services.Venues
{
    public interface IVenuesModifyingService
    {
        Task AddVenue(Venue venue);

        Task UpdateVenue(Venue venue);

        Task DeleteVenue(Guid venueId);
    }
}
