using Dapper;
using HospitalProject.Data;
using HospitalProject.Models;
using System.Data;

namespace HospitalProject.Repositories.Room
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public RoomsRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<RoomsModel> GetAll()
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_habitaciones";

                return connection.Query<RoomsModel>(storeProcedure, commandType: CommandType.StoredProcedure);
            }
        }

        public RoomsModel? GetById(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_select_byId_habitaciones";

                return connection.QueryFirstOrDefault<RoomsModel>(storeProcedure, new { HabitacionID = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void AddRoom(RoomsModel roomsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_insert_Habitacion";

                connection.Execute(storeProcedure, new { roomsModel.NumeroHabitacion },
                                   commandType: CommandType.StoredProcedure);
            }
        }

        public void EditRoom(RoomsModel roomsModel)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_update_habitaciones";

                connection.Execute(storeProcedure, roomsModel, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteRoom(int id)
        {
            using (var connection = _dataAccess.GetConnection())
            {
                string storeProcedure = "dbo.sp_delete_habitaciones";

                connection.Execute(storeProcedure, new { HabitacionID = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}