namespace EventApi.Models.Events
{
    public record EventsFilter(
        DateTime? From,
        DateTime? To,
        bool Announced,
        int PageSize,
        int PageNumber);
}
