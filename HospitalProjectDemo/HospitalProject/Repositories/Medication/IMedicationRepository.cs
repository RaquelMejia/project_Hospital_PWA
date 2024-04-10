using HospitalProject.Models;

namespace HospitalProject.Repositories.Medication
{
    public interface IMedicationRepository
    {
        IEnumerable<MedicationsModel> GetAll();
        MedicationsModel? GetById(int id);
        void AddMedication(MedicationsModel medicationsModel);
        void EditMedication(MedicationsModel medicationsModel);
        void DeleteMedication(int id);
    }
}