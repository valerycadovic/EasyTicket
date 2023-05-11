﻿using EventApi.Models.Events;
using EventApi.Models.Venues;
using EventApi.Services.Events;

namespace EventApi.Views
{
    public static class EventViewMapping
    {
        public static Event ToEntity(this PostEventView self) => new(
            Name: self.Name,
            Description: self.Description,
            Status: self.Status,
            TicketsInfo: TicketsInfo.TicketsAvailable,
            SoldOut: false,
            DateTime: self.DateTime,
            VenueId: self.VenueId)
        {
            Id = Guid.NewGuid()
        };

        public static EventExtended ToView(this Event self, Venue venue) => new(
            Id: self.Id,
            Name: self.Name,
            Description: self.Name,
            Status: self.Status,
            TicketsInfo: self.TicketsInfo,
            SoldOut: self.SoldOut,
            DateTime: self.DateTime,
            Venue: venue);
    }
}
