using EventApi.Models.Venues;

namespace EventApi.Services.Venues
{
    public interface IVenuesRetrievingService
    {
        Task<IEnumerable<Venue>> GetVenues(VenuesFilter filter);

        Task<IEnumerable<Venue>> GetVenues(IReadOnlyCollection<Guid> venueIds);

        Task<Venue> GetVenue(Guid venueId);
    }
}
