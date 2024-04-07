using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace HospitalProject.Models
{
    public class DoctorsModel
    {
        [Required]
        public int DoctorID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public int EspecialidadID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Dui { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Contacto { get; set; }

        public DoctorSpecialtyModel? Especialidades { get; set; }
    }
}
