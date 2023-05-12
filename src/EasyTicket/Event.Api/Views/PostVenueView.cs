using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.Views
{
    public record PostVenueView(
        [Required]
        [StringLength(50)]
        string Name,

        [Required]
        [StringLength(50)]
        string Address,

        [Required]
        [StringLength(1000)]
        string Description);
}
