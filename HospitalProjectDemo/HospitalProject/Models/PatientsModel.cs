using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace HospitalProject.Models
{
    public class PatientsModel
    {
        [Required]
        public int PacienteID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string NombreCompleto { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Dui { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Contacto { get; set; }
    }
}
