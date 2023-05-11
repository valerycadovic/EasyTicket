using Newtonsoft.Json;

namespace EventApi.Models.Events
{
    public record Event(
        string Name,
        string Description,
        EventStatus Status,
        TicketsInfo TicketsInfo,
        bool SoldOut,
        DateTime? DateTime,
        Guid VenueId)
    {
        [JsonProperty("id")]
        public Guid Id { get; init; }
    }
}
