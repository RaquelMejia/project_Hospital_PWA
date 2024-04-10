using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using System.Data;

namespace HospitalProject.Repositories.Consultation
{
    public class ConsultationsRepository : IConsultationsRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ConsultationsRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<DoctorsModel> GetAllDoctors()
        {
            string query = "SELECT DoctorID, NombreCompleto FROM Doctores";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<DoctorsModel>(query);
            }
        }

        public IEnumerable<MedicinesModel> GetAllMedicines()
        {
            string query = "SELECT MedicamentoID, Nombre FROM Medicamentos";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<MedicinesModel>(query);
            }
        }

        public IEnumerable<PatientsModel> GetAllPatients()
        {
            string query = "SELECT PacienteID, NombreCompleto FROM Pacientes";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<PatientsModel>(query);
            }
        }

        public IEnumerable<ConsultationModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "sp_select_consulta";

                var consultations = connection.Query<ConsultationModel, PatientsModel, DoctorsModel, MedicinesModel, ConsultationModel>
                    (storeProcedure, (consultation, patient, doctor, medicines) =>
                    {
                        consultation.Pacientes = patient;
                        consultation.Medicinas = medicines;
                        consultation.Doctores = doctor;

                        return consultation;
                    },
                    splitOn: "NombreCompleto, NombreCompleto, Nombre",
                    commandType: CommandType.StoredProcedure);

                return consultations;
            }
        }

        public ConsultationModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_consulta";

                return connection.QueryFirstOrDefault<ConsultationModel>(storeProcedure, new { ConsultaID = id },
                                                                               commandType: CommandType.StoredProcedure);
            }
        }

        public void AddConsultations(ConsultationModel consultationModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_consulta";

                connection.Execute(storeProcedure, new { consultationModel.FechaConsulta, consultationModel.Diagnostico, 
                                                         consultationModel.PacienteID, consultationModel.DoctorID, 
                                                         consultationModel.MedicamentoID },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditConsultations(ConsultationModel consultationModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_consulta";

                connection.Execute(storeProcedure,
                    new
                    {
                        consultationModel.ConsultaID,
                        consultationModel.FechaConsulta,
                        consultationModel.Diagnostico,
                        consultationModel.PacienteID,
                        consultationModel.DoctorID,
                        consultationModel.MedicamentoID
                    }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteConsultations(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_consulta";

                connection.Execute(storeProcedure, new { ConsultaID = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
