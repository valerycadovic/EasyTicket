using CommonLibrary.Models.Venues;

namespace CommonLibrary.Models.Events
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
