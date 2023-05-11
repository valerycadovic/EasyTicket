using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EventApi.Models.Events
{
    public enum TicketsInfo
    {
        [Display(Name = "Sold Out")]
        SoldOut,

        [Display(Name = "Tickets Available")]
        TicketsAvailable,

        [Display(Name = "Last Tickets Available")]
        LastTicketsAvailable
    }
}
