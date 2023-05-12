using CommonLibrary.Models.Events;
using CommonLibrary.Services.Events;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static CommonLibrary.Controllers.Events.EventModelValidation;

namespace CommonLibrary.Controllers.Events
{
    [Route("api/events")]
    public class EventsController : Controller
    {
        private readonly IEventsRetrievingService _eventsRetrievingService;

        public EventsController(IEventsRetrievingService eventsRetrievingService)
        {
            _eventsRetrievingService = eventsRetrievingService;
        }

        [HttpGet]
        public async Task<IResult> GetEvents(
            [FromHeader] DateTime? from,
            [FromHeader] DateTime? to,
            [FromHeader] bool announced,
            [FromHeader] int pageSize,
            [FromHeader, Range(1, int.MaxValue)] int pageNumber)
        {
            EventsFilter filter = new(
                From: from,
                To: to,
                Announced: announced,
                PageSize: pageSize,
                PageNumber: pageNumber);

            string? message = null;
            if (!ModelState.IsValid || !ValidateFilter(filter, out message))
            {
                message ??= "Model Invalid";

                return Results.BadRequest(new { Message = message, Model = filter});
            }

            IEnumerable<EventExtended> result = await _eventsRetrievingService.GetEvents(filter);

            return Results.Ok(result.ToList());
        }
    }
}
