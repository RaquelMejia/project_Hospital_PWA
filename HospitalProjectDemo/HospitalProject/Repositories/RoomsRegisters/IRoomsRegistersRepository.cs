using HospitalProject.Models;

namespace HospitalProject.Repositories.RoomsRegisters
{
    public interface IRoomsRegistersRepository
    {
        void AddRoomRegister(RoomsRegistrationsModel roomRegistrationModel);
        void DeleteRoomRegister(int id);
        void EditRoomRegister(RoomsRegistrationsModel roomRegistrationModel);
        IEnumerable<RoomsRegistrationsModel> GetAll();
        RoomsRegistrationsModel? GetById(int id);

        IEnumerable<RoomsModel> GetAllRooms();
        IEnumerable<PatientsModel> GetAllPatients();
    }
}
