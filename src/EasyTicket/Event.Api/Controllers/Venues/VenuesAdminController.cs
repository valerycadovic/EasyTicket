using EventApi.Exceptions;
using EventApi.Models.Venues;
using EventApi.Services.Venues;
using EventApi.Views;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers.Venues
{
    [Route("api/admin/venues")]
    public class VenuesAdminController : Controller
    {
        private readonly IVenuesModifyingService _venuesModifyingService;

        public VenuesAdminController(IVenuesModifyingService venuesModifyingService)
        {
            _venuesModifyingService = venuesModifyingService;
        }

        [HttpPost]
        public async Task<IResult> PostVenue([FromBody] PostVenueView venueView)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(new { Message = "Model Invalid", Model = venueView });
            }

            Venue venue = venueView.ToEntity();
            await _venuesModifyingService.AddVenue(venue);

            return Results.Accepted("/");
        }

        [HttpPut]
        public async Task<IResult> PutVenue([FromBody] Venue venue)
        {
            try
            {
                await _venuesModifyingService.UpdateVenue(venue);

                return Results.NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return Results.NotFound(new { ex.EntityId, ex.EntityType.Name });
            }
        }
    }
}
