using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static dreamCare.ApiService.Models.ModelExtensions;

namespace dreamCare.ApiService.Models
{

    [PrimaryKey(nameof(pUserId))]
    public record PatientUser
    {
        [Required]
        public Guid pUserId { get; }

        [Required(ErrorMessage = "Patient requires a first name")]
        [Display(Name = "First Name")]
        public required string pUserFirstName { get; set; } = "";

        [Required(ErrorMessage = "Patient requires a last name")]
        [Display(Name = "Last Name")]
        public required string pUserLastName { get; set; } = "";

        [Required(ErrorMessage = "Patient requires a gender identity")]
        [Display(Name = "Gender Identity")]
        public required UserGenderIdentity pUserGenderIdentity { get; set; }

        [Required(ErrorMessage = "Patient requires an age")]
        [Display(Name = "Age")]
        public required int pUserAge { get; set; }

        [DisplayFormat(NullDisplayText = "No Appointments")]
        public ICollection<Appointment>? appointments { get; set; }

        [Required]
        public required DateTime registerDate { get; set; }

        [Required]
        public required DateTime lastCheckUp { get; set; }

        [Required]
        public required bool isReferred { get; set; }

        [Required(ErrorMessage = "Permissions are required")]
        [Display(Name = "User Permissions")]
        public required UserPermission userPermission { get; set; }

    }
}