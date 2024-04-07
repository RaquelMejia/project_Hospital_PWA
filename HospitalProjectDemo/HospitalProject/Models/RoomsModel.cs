using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class RoomsModel
    {
        [Required]
        public int HabitacionID { get; set; }

        [Required]
        public string NumeroHabitacion { get; set; }
    }
}
