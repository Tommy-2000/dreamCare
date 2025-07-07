using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dreamCare.ApiService.Models
{
    [PrimaryKey(nameof(departmentId))]
    public record Department
    {
        [Required]
        public Guid departmentId { get; }

        [Required(ErrorMessage = "Department requires a type")]
        [Display(Name = "Department Type")]
        public required string departmentType { get; set; } = "";

        [Required, DisplayFormat(NullDisplayText = "No GPs")]
        public required ICollection<GPUser> gpUsers { get; set; }

        [Required, DisplayFormat(NullDisplayText = "No Nurses")]
        public required ICollection<NurseUser> nurseUsers { get; set; }


    }
}
