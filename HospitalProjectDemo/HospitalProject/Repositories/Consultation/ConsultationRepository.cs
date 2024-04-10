using HospitalProject.Data;
using HospitalProject.Models;
using HospitalProject.Repositories.Medication;
using HospitalProject.Repositories.Patients;
using System.Data;

namespace HospitalProject.Repositories.Consultation
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ConsultationRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<ConsultationsModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_consulta";

                return connection.Query<ConsultationsModel>(storeProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public ConsultationsModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_consulta";

                return connection.QueryFirstOrDefault<ConsultationsModel>(storeProcedure, new { ConsultaID = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddConsultation(ConsultationsModel consultationsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_consulta";
                connection.Execute(storeProcedure, new { consultationsModel.ConsultaID, consultationsModel.Diagnostico, consultationsModel.FechaConsulta },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditConsultation(ConsultationsModel consultationsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_consulta";

                connection.Execute(storeProcedure, consultationsModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteConsultation(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_consulta";

                connection.Execute(storeProcedure, new { ConsultaID = id }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}

