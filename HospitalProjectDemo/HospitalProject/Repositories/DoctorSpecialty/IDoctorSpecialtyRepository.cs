using HospitalProject.Models;

namespace HospitalProject.Repositories.DoctorSpecialty
{
    public interface IDoctorSpecialtyRepository
    {
        void AddDoctorSpecialty(DoctorSpecialtyModel doctorSpecialty);
        void DeleteDoctorSpecialty(int id);
        void EditDoctorSpecialty(DoctorSpecialtyModel doctorSpecialty);
        IEnumerable<DoctorSpecialtyModel> GetAll();
        DoctorSpecialtyModel? GetById(int id);
    }
}
