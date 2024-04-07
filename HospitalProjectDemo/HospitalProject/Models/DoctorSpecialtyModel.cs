using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class DoctorSpecialtyModel
    {
        [Required]
        public int EspecialidadID { get; set; }

        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string NombreEspecialidad { get; set;}

        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string DescripcionEspecialidad { get; set;}
    }
}
