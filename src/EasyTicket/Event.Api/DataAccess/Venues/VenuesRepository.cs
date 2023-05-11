using EventApi.Models.Venues;

namespace EventApi.DataAccess.Venues
{
    public sealed class VenuesRepository : Repository<Venue, VenuesFilter>, IVenuesRepository
    {
        public VenuesRepository(VenuesContainerAdapter adapter) : base(adapter.Container)
        {
        }

        public async Task<IEnumerable<Venue>> GetVenues(IReadOnlyCollection<Guid> ids)
        {
            IQueryable<Venue> queryable = _container.GetItemLinqQueryable<Venue>()
                .Where(v => ids.Contains(v.Id));

            return await ExecuteQueryable(queryable);
        }

        protected override IQueryable<Venue> FilterInternal(IQueryable<Venue> queryable, VenuesFilter filter)
        {
            queryable = string.IsNullOrEmpty(filter.NameSearchPattern)
                ? queryable
                : queryable.Where(v => v.Name.Contains(filter.NameSearchPattern));

            queryable = string.IsNullOrEmpty(filter.AddressSearchPattern)
                ? queryable
                : queryable.Where(v => v.Address.Contains(filter.AddressSearchPattern));

            return queryable;
        }
    }
}
