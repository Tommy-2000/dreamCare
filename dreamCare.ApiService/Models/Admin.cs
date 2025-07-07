using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static dreamCare.ApiService.Models.ModelExtensions;

namespace dreamCare.ApiService.Models
{
    [PrimaryKey(nameof(adminId))]
    public record Admin
    {
        [Required]
        public Guid adminId { get; }

        [Required(ErrorMessage = "Admin requires a first name")]
        [Display(Name = "First Name")]
        public required string aUserFirstName { get; set; } = "";

        [Required(ErrorMessage = "Admin requires a last name")]
        [Display(Name = "Last Name")]
        public required string aUserLastName { get; set; } = "";

        [Required(ErrorMessage = "A register date is required")]
        [Display(Name = "Date Registered")]
        public required DateTime registerDate { get; set; }

        [Required(ErrorMessage = "A previous login time is required")]
        [Display(Name = "Time Last Logged In")]
        public required DateTime lastLoggedIn { get; set; }

        [Required(ErrorMessage = "Permissions are required")]
        [Display(Name = "User Permissions")]
        public required UserPermission userPermission { get; set; }
    }
}
