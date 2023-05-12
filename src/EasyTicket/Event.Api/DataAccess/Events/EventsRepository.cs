using CommonLibrary.Models.Events;

namespace CommonLibrary.DataAccess.Events
{
    public sealed class EventsRepository : Repository<Event, EventsFilter>
    {
        public EventsRepository(EventsContainerAdapter adapter) : base(adapter.Container)
        {
        }

        protected override IQueryable<Event> FilterInternal(IQueryable<Event> queryable, EventsFilter filter)
        {
            if (filter.From.HasValue && filter.To.HasValue)
            {
                queryable = queryable
                    .Where(e => e.DateTime >= filter.From.Value && e.DateTime <= filter.To.Value);
            }

            if (filter.Announced)
            {
                queryable = queryable
                    .Where(e => e.Status == EventStatus.Announced);
            }

            queryable = queryable
                .OrderBy(e => e.DateTime)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            return queryable;
        }
    }
}
