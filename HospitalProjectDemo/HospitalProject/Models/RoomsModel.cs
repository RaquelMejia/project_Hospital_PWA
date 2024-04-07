using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class RoomsModel
    {
        [Required]
        public int HabitacionID { get; set; }

        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string NumeroHabitacion { get; set; }
    }
}
