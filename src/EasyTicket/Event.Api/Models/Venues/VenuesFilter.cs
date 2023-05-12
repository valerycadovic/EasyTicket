namespace CommonLibrary.Models.Venues
{
    public record VenuesFilter(
        string? NameSearchPattern,
        string? AddressSearchPattern);
}
