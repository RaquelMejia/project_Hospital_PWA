using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using System.Data;

namespace HospitalProject.Repositories.DoctorSpecialty
{
    public class DoctorSpecialtyRepositories : IDoctorSpecialtyRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public DoctorSpecialtyRepositories(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<DoctorSpecialtyModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "sp_select_especialidadDoctor";

                return connection.Query<DoctorSpecialtyModel>(storeProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public DoctorSpecialtyModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_especialidadDoctor";

                return connection.QueryFirstOrDefault<DoctorSpecialtyModel>(storeProcedure, new { EspecialidadID = id },commandType: CommandType.StoredProcedure);
            }
        }

        public void AddDoctorSpecialty(DoctorSpecialtyModel doctorSpecialty)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_especialidadDoctor";

                connection.Execute(storeProcedure, new { doctorSpecialty.NombreEspecialidad, doctorSpecialty.DescripcionEspecialidad }, 
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditDoctorSpecialty(DoctorSpecialtyModel doctorSpecialty)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_especialidadDoctor";

                connection.Execute(storeProcedure, doctorSpecialty, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteDoctorSpecialty(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_especialidadDoctor";

                connection.Execute(storeProcedure, new { EspecialidadID = id }, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
