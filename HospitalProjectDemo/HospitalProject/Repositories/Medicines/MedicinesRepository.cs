using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using System.Data;

namespace HospitalProject.Repositories.Medicines
{
    public class MedicinesRepository : IMedicinesRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public MedicinesRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<MedicinesModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "sp_select_medicamentos";

                return connection.Query<MedicinesModel>(storeProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public MedicinesModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_medicamentos";

                return connection.QueryFirstOrDefault<MedicinesModel>(storeProcedure, new { MedicamentoID = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddMedicines(MedicinesModel medicinesModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_medicamentos";

                connection.Execute(storeProcedure, new { medicinesModel.Nombre, medicinesModel.Descripcion },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditMedicines(MedicinesModel medicinesModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_medicamentos";

                connection.Execute(storeProcedure, medicinesModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteMedicines(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_medicamentos";

                connection.Execute(storeProcedure, new { MedicamentoID = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
