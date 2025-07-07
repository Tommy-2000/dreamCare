using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dreamCare.ApiService.Models
{

    [PrimaryKey(nameof(assessmentId))]
    public record Assessment
    {
        [Required]
        public Guid assessmentId { get; }

        [Required(ErrorMessage = "Assessment requires a name")]
        [Display(Name = "Assessment Name")]
        public required string assessmentName { get; set; } = "";

        [Display(Name = "Assessment Notes")]
        public string assessmentNotes { get; set; } = "";

        [Required(ErrorMessage = "Referral must be marked recommended or not")]
        [Display(Name = "Is a Referral Recommended?")]
        public required bool recommendReferral { get; set; }

    }
}
