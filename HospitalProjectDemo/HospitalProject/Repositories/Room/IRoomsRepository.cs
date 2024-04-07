using HospitalProject.Models;

namespace HospitalProject.Repositories.Room
{
    public interface IRoomsRepository
    {
        void AddRoom(RoomsModel roomsModel);
        void DeleteRoom(int id);
        void EditRoom(RoomsModel roomsModel);
        IEnumerable<RoomsModel> GetAll();
        RoomsModel? GetById(int id);
    }
}
