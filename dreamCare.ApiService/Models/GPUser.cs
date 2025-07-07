using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static dreamCare.ApiService.Models.ModelExtensions;

namespace dreamCare.ApiService.Models
{

    [PrimaryKey(nameof(gpUserId))]
    public record GPUser
    {
        [Required]
        public Guid gpUserId { get; }

        [Required(ErrorMessage = "GP requires a first name")]
        [Display(Name = "First Name")]
        public required string gpUserFirstName { get; set; } = "";

        [Required(ErrorMessage = "GP requires a last name")]
        [Display(Name = "Last Name")]
        public required string gpUserLastName { get; set; } = "";

        [Required(ErrorMessage = "GP requires a gender identity")]
        [Display(Name = "Gender Identity")]
        public required UserGenderIdentity gpUserGenderIdentity { get; set; }

        [Required(ErrorMessage = "GP requires a practice type")]
        [Display(Name = "Type of Practice")]
        public required string gpPracticeType { get; set; } = "";
                
        [Required(ErrorMessage = "GP requires a role level")]
        [Display(Name = "Role Level")]
        public required RoleLevel roleLevel { get; set; }

        [Required(ErrorMessage = "GP must be marked available or not")]
        [Display(Name = "Is the GP Currently Available?")]
        public required bool isGPCurrentlyAvailable { get; set; }

        [DisplayFormat(NullDisplayText = "No Appointments")]
        public ICollection<Appointment>? appointments { get; set; }

        [Required]
        public required DateTime registerDate { get; set; }

        [Required]
        public required DateTime lastLoggedIn { get; set; }

        [Required(ErrorMessage = "Permissions are required")]
        [Display(Name = "User Permissions")]
        public required UserPermission userPermission { get; set; }

    }
}