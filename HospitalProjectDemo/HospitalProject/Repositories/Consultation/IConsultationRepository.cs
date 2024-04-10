using HospitalProject.Models;

namespace HospitalProject.Repositories.Consultation
{
    public interface IConsultationRepository
    {
        IEnumerable<ConsultationsModel> GetAll();
        ConsultationsModel? GetById(int id);
        void AddConsultation(ConsultationsModel consultationsModel);
        void EditConsultation(ConsultationsModel consultationsModel);
        void DeleteConsultation(int id);
    }
}
