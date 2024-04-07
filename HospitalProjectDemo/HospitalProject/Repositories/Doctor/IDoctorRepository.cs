using HospitalProject.Models;

namespace HospitalProject.Repositories.Doctor
{
    public interface IDoctorRepository
    {
        void AddDoctor(DoctorsModel doctorsModel);
        void DeleteDoctor(int id);
        void EditDoctor(DoctorsModel doctorsModel);
        IEnumerable<DoctorsModel> GetAll();
        DoctorsModel? GetById(int id);

        IEnumerable<DoctorSpecialtyModel> GetAllSpecialty();
    }
}
