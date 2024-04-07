using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace HospitalProject.Repositories.Doctor
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ISqlDataAccess _dataAccess;


        public DoctorRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<DoctorsModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "sp_select_doctor";

                var doctors = connection.Query<DoctorsModel, DoctorSpecialtyModel, DoctorsModel>
                    (storeProcedure, (doctor, specialty) =>
                    {
                        doctor.Especialidades = specialty;

                        return doctor;
                    },
                    splitOn: "NombreEspecialidad",
                    commandType: CommandType.StoredProcedure);

                return doctors;
            }
        }

        public IEnumerable<DoctorSpecialtyModel> GetAllSpecialty()
        {
            string query = "SELECT EspecialidadID, NombreEspecialidad FROM EspecialidadDoctor;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<DoctorSpecialtyModel>(query);
            }
        }

        public DoctorsModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_doctor";

                return connection.QueryFirstOrDefault<DoctorsModel>(storeProcedure, new { DoctorID = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddDoctor(DoctorsModel doctorsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_doctor";

                connection.Execute(storeProcedure, new { doctorsModel.NombreCompleto, doctorsModel.EspecialidadID, doctorsModel.Dui, doctorsModel.Contacto },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditDoctor(DoctorsModel doctorsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_doctor";

                connection.Execute(storeProcedure,
                    new { doctorsModel.DoctorID, doctorsModel.NombreCompleto, doctorsModel.EspecialidadID, doctorsModel.Dui, doctorsModel.Contacto }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteDoctor(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_doctor";

                connection.Execute(storeProcedure, new { DoctorID = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
