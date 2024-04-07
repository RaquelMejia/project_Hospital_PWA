using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using System.Data;

namespace HospitalProject.Repositories.RoomsRegisters
{
    public class RoomsRegistersRepository : IRoomsRegistersRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public RoomsRegistersRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<PatientsModel> GetAllPatients()
        {
            string query = "SELECT PacienteID, NombreCompleto FROM Pacientes;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<PatientsModel>(query);
            }
        }

        public IEnumerable<RoomsModel> GetAllRooms()
        {
            string query = "SELECT HabitacionID, NumeroHabitacion FROM Habitaciones;";

            using (var connection = _dataAccess.GetConnection())
            {
                return connection.Query<RoomsModel>(query);
            }
        }

        public IEnumerable<RoomsRegistrationsModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "sp_select_registroHabitaciones";

                var rooms = connection.Query<RoomsRegistrationsModel, RoomsModel, PatientsModel, RoomsRegistrationsModel>
                    (storeProcedure, (roomRegistration, room, patient) =>
                    {
                        roomRegistration.NumeroHabitacion = room;
                        roomRegistration.NombrePaciente = patient;

                        return roomRegistration;
                    },
                    splitOn: "NumeroHabitacion, NombreCompleto",
                    commandType: CommandType.StoredProcedure);

                return rooms;
            }
        }

        public RoomsRegistrationsModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_registroHabitaciones";

                return connection.QueryFirstOrDefault<RoomsRegistrationsModel>(storeProcedure, new { RegistroHabitacionID = id }, 
                                                                               commandType: CommandType.StoredProcedure);
            }
        }

        public void AddRoomRegister(RoomsRegistrationsModel roomRegistrationModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_registroHabitaciones";

                connection.Execute(storeProcedure, new { roomRegistrationModel.HabitacionID, roomRegistrationModel.PacienteID },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditRoomRegister(RoomsRegistrationsModel roomRegistrationModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_registroHabitaciones";

                connection.Execute(storeProcedure,
                    new { roomRegistrationModel.RegistroHabitacionID, roomRegistrationModel.HabitacionID, roomRegistrationModel.PacienteID }
                    , commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteRoomRegister(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_registroHabitaciones";

                connection.Execute(storeProcedure, new { RegistroHabitacionID = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
