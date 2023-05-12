using CommonLibrary.Models.Venues;

namespace CommonLibrary.Views
{
    public static class VenueViewMapping
    {
        public static Venue ToEntity(this PostVenueView self) => new(
            Name: self.Name,
            Address: self.Address,
            Description: self.Description)
        {
            Id = Guid.NewGuid()
        };
    }
}
