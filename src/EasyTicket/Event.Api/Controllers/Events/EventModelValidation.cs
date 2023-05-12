using CommonLibrary.Models.Events;
using CommonLibrary.Views;

namespace CommonLibrary.Controllers.Events
{
    public static class EventModelValidation
    {
        public static bool ValidateEvent(PostEventView model, out string? message)
        {
            message = null;

            if (model.Status == EventStatus.Announced && model.DateTime.HasValue)
            {
                message = $"{nameof(PostEventView.DateTime)} cannot be set when {nameof(PostEventView.Status)} is {EventStatus.Announced}";

                return false;
            }

            if (model.Status != EventStatus.Announced && !model.DateTime.HasValue)
            {
                message = $"{nameof(PostEventView.DateTime)} must be set when {nameof(PostEventView.Status)} is not {EventStatus.Announced}";
            }

            return true;
        }

        public static bool ValidateFilter(EventsFilter filter, out string? message)
        {
            message = null;

            if (filter.From.HasValue ^ filter.To.HasValue)
            {
                message = $"{nameof(EventsFilter.From)} and {nameof(EventsFilter.To)} must be both defined or both undefined";

                return false;
            }

            if (filter.From > filter.To)
            {
                message = $"{nameof(EventsFilter.From)} date cannot be later then {nameof(EventsFilter.To)} date";

                return false;
            }

            if (filter.Announced && filter.From.HasValue && filter.To.HasValue)
            {
                message = $"dates must not be set when {nameof(EventsFilter.Announced)} is set";

                return false;
            }

            if (!filter.Announced && !filter.From.HasValue && !filter.To.HasValue)
            {
                message = $"dates must be set when {nameof(EventsFilter.Announced)} is not set";

                return false;
            }

            return true;
        }
    }
}
