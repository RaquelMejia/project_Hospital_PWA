using HospitalProject.Models;
using HospitalProject.Repositories.Consultation;
using HospitalProject.Repositories.Medication;
using HospitalProject.Repositories.Patients;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationController(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }

        public ActionResult Index()
        {
            return View(_consultationRepository.GetAll());
        }

        // GET: UniverstiyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniverstiyController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultationsModel consultationsModel)
        {
            try
            {
                _consultationRepository.AddConsultation(consultationsModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(consultationsModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var patient = _consultationRepository.GetById(id);

            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsultationsModel consultationsModel)
        {
            try
            {
                _consultationRepository.EditConsultation(consultationsModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(consultationsModel);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var medication = _consultationRepository.GetById(id);

            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ConsultationsModel consultationsModel)
        {
            try
            {
                _consultationRepository.DeleteConsultation(consultationsModel.ConsultaID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(consultationsModel);
            }
        }
    }
}
