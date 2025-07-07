using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static dreamCare.ApiService.Models.ModelExtensions;

namespace dreamCare.ApiService.Models
{

    [PrimaryKey(nameof(nUserId))]
    public record NurseUser
    {
        [Required]
        public Guid nUserId { get; }

        [Required(ErrorMessage = "Nurse requires a first name")]
        [Display(Name = "First Name")]
        public required string nUserFirstName { get; set; } = "";

        [Required(ErrorMessage = "Nurse requires a last name")]
        [Display(Name = "Last Name")]
        public required string nUserLastName { get; set; } = "";

        [Required(ErrorMessage = "Nurse requires a gender identity")]
        [Display(Name = "Gender Identity")]
        public required UserGenderIdentity nUserGenderIdentity { get; set; }

        [Required(ErrorMessage = "Nurse requires a practice type")]
        [Display(Name = "Type of Practice")]
        public required string nPracticeType { get; set; } = "";

        [Required(ErrorMessage = "Nurse requires a role level")]
        [Display(Name = "Role Level")]
        public required RoleLevel roleLevel { get; set; }

        [Required(ErrorMessage = "Nurse must be marked available or not")]
        [Display(Name = "Is the Nurse Currently Available?")]
        public required bool isNurseCurrentlyAvailable { get; set; }

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