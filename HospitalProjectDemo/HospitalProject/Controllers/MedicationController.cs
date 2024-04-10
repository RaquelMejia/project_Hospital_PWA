using HospitalProject.Models;
using HospitalProject.Repositories.Medication;
using HospitalProject.Repositories.Patients;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class MedicationController : Controller
    {
        private readonly IMedicationRepository _medicationRepository;

        public MedicationController(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public ActionResult Index()
        {
            return View(_medicationRepository.GetAll());
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
        public ActionResult Create(MedicationsModel medicationsModel)
        {
            try
            {
                _medicationRepository.AddMedication(medicationsModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(medicationsModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var patient = _medicationRepository.GetById(id);

            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicationsModel medicationsModel)
        {
            try
            {
                _medicationRepository.EditMedication(medicationsModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(medicationsModel);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var medication = _medicationRepository.GetById(id);

            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MedicationsModel medicationsModel)
        {
            try
            {
                _medicationRepository.DeleteMedication(medicationsModel.MedicamentoID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(medicationsModel);
            }
        }
    }
}
