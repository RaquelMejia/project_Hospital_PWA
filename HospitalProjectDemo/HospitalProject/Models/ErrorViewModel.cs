using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class ErrorViewModel
    {
        [Required]
        public string? RequestId { get; set; }

        [Required]
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
