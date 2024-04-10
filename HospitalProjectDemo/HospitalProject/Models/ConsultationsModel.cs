using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace HospitalProject.Models
{
    public class ConsultationsModel
    {
        [Required]
        public int ConsultaID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public int PacienteID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public int DoctorID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public int MedicamentoID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Diagnostico { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public int FechaConsulta { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]

    }
}
