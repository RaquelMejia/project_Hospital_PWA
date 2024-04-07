using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class RoomsRegistrationsModel
    {
        [Required]
        public int RegistroHabitacionID { get; set; }

        [Required]
        public int HabitacionID { get; set; }

        [Required]
        public int PacienteID { get; set; }

        public RoomsModel? NumeroHabitacion { get; set; }
        public PatientsModel? NombrePaciente { get; set; }
    }
}
