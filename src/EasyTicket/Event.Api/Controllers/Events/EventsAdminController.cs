using EventApi.Exceptions;
using EventApi.Models.Events;
using EventApi.Services.Events;
using EventApi.Views;
using Microsoft.AspNetCore.Mvc;
using static EventApi.Controllers.Events.EventModelValidation;

namespace EventApi.Controllers.Events
{
    [Route("api/admin/events")]
    public class EventsAdminController : Controller
    {
        private readonly IEventsModifyingService _eventsModifyingService;

        public EventsAdminController(IEventsModifyingService eventsModifyingService)
        {
            _eventsModifyingService = eventsModifyingService;
        }

        [HttpPost]
        public async Task<IResult> PostEvent([FromBody] PostEventView postEventView)
        {
            string? message = null;
            if (!ModelState.IsValid || !ValidateEvent(postEventView, out message))
            {
                message ??= "Model Invalid";
                return Results.BadRequest(new { Message = message, Model = postEventView });
            }

            Event @event = postEventView.ToEntity();
            await _eventsModifyingService.AddEvent(@event);

            return Results.Accepted("/events");
        }

        [HttpPut]
        public async Task<IResult> PutEvent([FromBody] Event @event)
        {
            try
            {
                await _eventsModifyingService.UpdateEvent(@event);

                return Results.NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return Results.NotFound(new { ex.EntityId, ex.EntityType.Name });
            }
        }

        [HttpPatch]
        public async Task<IResult> UpdateEventStatus([FromQuery] Guid eventId, [FromBody] EventStatus status)
        {
            try
            {
                await _eventsModifyingService.UpdateEventStatus(eventId, status);

                return Results.NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return Results.NotFound(new { ex.EntityId, ex.EntityType.Name });
            }
        }
    }
}
