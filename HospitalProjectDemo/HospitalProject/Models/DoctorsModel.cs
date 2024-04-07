using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics.Contracts;

namespace HospitalProject.Models
{
    public class DoctorsModel
    {
        public int DoctorID { get; set; }
        public string NombreCompleto { get; set; }
        public int EspecialidadID { get; set; }
        public string Dui { get; set; } 
        public string Contacto { get; set; }

        public DoctorSpecialtyModel? Especialidades { get; set; }
    }
}
