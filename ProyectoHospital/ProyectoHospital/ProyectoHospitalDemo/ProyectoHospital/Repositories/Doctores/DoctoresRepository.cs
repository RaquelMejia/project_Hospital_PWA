using Dapper;
using System.Data;
using Hospital.Models;
using Hospital.Data;

namespace Hospital.Repositories.Doctores
{
    public class DoctoresRepository : IDoctoresRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public DoctoresRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Hospital> GetAllHospitales()
        {
            string query = "SELECT Id, NombreCompleto FROM Hospital;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<Hospital>(query);
            }

        }

        public IEnumerable<Doctores> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storedProcedure = "dbo.spDoctores_GetAll";

                var doctores = connection.Query<Doctores, Hospital, Doctores>
                    (storedProcedure,(doctores, hospital) =>

                return connection.Query<Doctores>(storedProcedure, commandType: CommandType.StoredProcedure);
            }
        }


        string? IDoctoresRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        object IDoctoresRepository.GetAllHospitales()
        {
            throw new NotImplementedException();
        }
    }
}
