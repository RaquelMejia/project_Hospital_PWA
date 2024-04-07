using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Contracts;

namespace HospitalProject.Models
{
    public class PatientsModel
    {
        public int PacienteID { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }
        public string Dui { get; set; }
        public string Contacto { get; set; }
    }
}
