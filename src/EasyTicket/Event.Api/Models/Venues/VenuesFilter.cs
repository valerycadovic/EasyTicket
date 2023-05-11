namespace EventApi.Models.Venues
{
    public record VenuesFilter(
        string? NameSearchPattern,
        string? AddressSearchPattern);
}
