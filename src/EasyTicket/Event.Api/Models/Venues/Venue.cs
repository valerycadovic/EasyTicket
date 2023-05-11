using Newtonsoft.Json;

namespace EventApi.Models.Venues
{
    public record Venue(
        string Name,
        string Address,
        string Description)
    {
        [JsonProperty("id")]
        public Guid Id { get; init; }
    }
}
