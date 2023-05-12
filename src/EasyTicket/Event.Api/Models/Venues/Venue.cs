using Newtonsoft.Json;

namespace CommonLibrary.Models.Venues
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
