using HospitalProject.Models;

namespace HospitalProject.Repositories.Medicines
{
    public interface IMedicinesRepository
    {
        void AddMedicines(MedicinesModel medicinesModel);
        void DeleteMedicines(int id);
        void EditMedicines(MedicinesModel medicinesModel);
        IEnumerable<MedicinesModel> GetAll();
        MedicinesModel? GetById(int id);
    }
}
