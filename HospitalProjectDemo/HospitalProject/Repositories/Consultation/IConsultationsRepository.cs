using HospitalProject.Models;

namespace HospitalProject.Repositories.Consultation
{
    public interface IConsultationsRepository
    {
        void AddConsultations(ConsultationModel consultationModel);
        void EditConsultations(ConsultationModel consultationModel);
        void DeleteConsultations(int id);
        IEnumerable<ConsultationModel> GetAll();
        ConsultationModel? GetById(int id);

        IEnumerable<PatientsModel> GetAllPatients();
        IEnumerable<DoctorsModel> GetAllDoctors();
        IEnumerable<MedicinesModel> GetAllMedicines();
    }
}
