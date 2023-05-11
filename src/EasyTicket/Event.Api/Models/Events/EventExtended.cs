using EventApi.Models.Venues;

namespace EventApi.Models.Events
{
    public record EventExtended(
        Guid Id,
        string Name,
        string Description,
        EventStatus Status,
        TicketsInfo TicketsInfo,
        bool SoldOut,
        DateTime? DateTime,
        Venue Venue);
}
