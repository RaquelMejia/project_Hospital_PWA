using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace HospitalProject.Models
{
    public class MedicationsModel
    {
        [Required]
        public int MedicamentoID { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        
    }
}

