using CommonLibrary.Models.Venues;
using CommonLibrary.Services.Venues;
using Microsoft.AspNetCore.Mvc;

namespace CommonLibrary.Controllers.Venues
{
    [Route("api/venues")]
    public class VenuesController : Controller
    {
        private readonly IVenuesRetrievingService _venuesRetrievingService;

        public VenuesController(IVenuesRetrievingService venuesRetrievingService)
        {
            _venuesRetrievingService = venuesRetrievingService;
        }

        [HttpGet]
        public async Task<IResult> GetVenues(
            [FromHeader] string nameSearchPattern,
            [FromHeader] string addressSearchPattern)
        {
            VenuesFilter filter = new(
                NameSearchPattern: nameSearchPattern,
                AddressSearchPattern: addressSearchPattern);

            IEnumerable<Venue> result = await _venuesRetrievingService.GetVenues(filter);

            return Results.Ok(result);
        }
    }
}
