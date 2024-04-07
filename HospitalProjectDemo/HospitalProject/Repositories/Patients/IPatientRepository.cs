using HospitalProject.Models;

namespace HospitalProject.Repositories.Patients
{
    public interface IPatientRepository
    {
        IEnumerable<PatientsModel> GetAll();
        PatientsModel? GetById(int id);
        void AddPatient(PatientsModel patientsModel);
        void EditPatient(PatientsModel patientsModel);
        void DeletePatient(int id);

    }
}
