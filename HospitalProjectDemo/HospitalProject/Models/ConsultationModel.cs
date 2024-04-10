using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalProject.Models
{
    public class ConsultationModel
    {
        public int ConsultaID { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Diagnostico { get; set; }
        public int PacienteID { get; set; }
        public int DoctorID { get; set; }
        public int MedicamentoID { get; set; }

        public PatientsModel? Pacientes { get; set; }
        public DoctorsModel? Doctores { get; set; }
        public MedicinesModel? Medicinas { get; set; }

    }
}
