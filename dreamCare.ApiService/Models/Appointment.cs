using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dreamCare.ApiService.Models
{

    [PrimaryKey(nameof(appointmentId))]
    public record Appointment
    {
        [Required]
        public Guid appointmentId { get; }

        [Required(ErrorMessage = "Appointment requires a name")]
        [Display(Name = "Appointment Name")]
        public required string appointmentName { get; set; } = "";

        public string appointmentNotes { get; set; } = "";

        [Required(ErrorMessage = "Appointment must be marked urgent or not")]
        [Display(Name = "Is the Appointment Urgent?")]
        public required bool isAppointmentUrgent { get; set; }

        [Required(ErrorMessage = "Appointment must be marked cancelled or not")]
        [Display(Name = "Is the Appointment Cancelled?")]
        public required bool isAppointmentCancelled { get; set; }

        [Required(ErrorMessage = "Appointment requires a date")]
        [Display(Name = "Date of Appointment")]
        public required DateOnly appointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment requires a time")]
        [Display(Name = "Time of Appointment")]
        public required TimeOnly appointmentTime { get; set; }

        [Required(ErrorMessage = "Appointment requires an Assessment")]
        public required Assessment assessment { get; set; }

    }
}
