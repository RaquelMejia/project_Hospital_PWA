using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using System.Data;

namespace HospitalProject.Repositories.Medication
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public MedicationRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<MedicationsModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_medicamento";

                return connection.Query<MedicationsModel>(storeProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public MedicationsModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_medicamento";

                return connection.QueryFirstOrDefault<MedicationsModel>(storeProcedure, new { MedicamentoID = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddMedication(MedicationsModel medicationsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_medicamento";

                connection.Execute(storeProcedure, new { medicationsModel.Nombre, medicationsModel.Descripcion },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditMedication(MedicationsModel medicationsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_medication";

                connection.Execute(storeProcedure, medicationsModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteMedication(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_medicamento";

                connection.Execute(storeProcedure, new { MedicamentoID = id }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}