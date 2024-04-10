using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalProject.Models
{
    public class MedicinesModel
    {
        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public int MedicamentoID { get; set; }

        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Campo no puede estar vacio")]
        public string Descripcion { get; set; }
    }
}
