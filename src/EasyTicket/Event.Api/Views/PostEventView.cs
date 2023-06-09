﻿using CommonLibrary.Models.Events;
using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.Views
{
    public record PostEventView(
        [Required]
        [StringLength(100)]
        string Name,

        [StringLength(1000)]
        string Description,

        [Required]
        EventStatus Status,

        [DataType(DataType.DateTime)]
        DateTime? DateTime,

        [Required]
        Guid VenueId);
}
