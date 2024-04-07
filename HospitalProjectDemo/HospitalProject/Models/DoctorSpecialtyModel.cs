using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class DoctorSpecialtyModel
    {
        [Required]
        public int EspecialidadID { get; set; }

        [Required]
        public string NombreEspecialidad { get; set;}

        [Required]
        public string DescripcionEspecialidad { get; set;}
    }
}
