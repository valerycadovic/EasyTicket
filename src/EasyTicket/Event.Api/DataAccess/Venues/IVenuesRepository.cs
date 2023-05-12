using CommonLibrary.DataAccess;
using CommonLibrary.Models.Venues;

namespace CommonLibrary.DataAccess.Venues
{
    public interface IVenuesRepository : IRepository<Venue, VenuesFilter>
    {
        Task<IEnumerable<Venue>> GetVenues(IReadOnlyCollection<Guid> ids);
    }
}
