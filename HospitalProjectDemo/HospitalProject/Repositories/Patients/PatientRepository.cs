using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using System.Data;

namespace HospitalProject.Repositories.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public PatientRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<PatientsModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_paciente";

                return connection.Query<PatientsModel>(storeProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public PatientsModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_paciente";

                return connection.QueryFirstOrDefault<PatientsModel>(storeProcedure, new { PacienteID = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddPatient(PatientsModel patientsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_paciente";

                connection.Execute(storeProcedure, new { patientsModel.NombreCompleto, patientsModel.Edad, patientsModel.Dui, patientsModel.Contacto },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditPatient(PatientsModel patientsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_paciente";

                connection.Execute(storeProcedure, patientsModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeletePatient(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_paciente";

                connection.Execute(storeProcedure, new { PacienteID = id }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
