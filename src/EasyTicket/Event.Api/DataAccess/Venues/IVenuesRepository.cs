using EventApi.Models.Venues;

namespace EventApi.DataAccess.Venues
{
    public interface IVenuesRepository : IRepository<Venue, VenuesFilter>
    {
        Task<IEnumerable<Venue>> GetVenues(IReadOnlyCollection<Guid> ids);
    }
}
