using HospitalProject.Models;
using HospitalProject.Repositories.DoctorSpecialty;
using HospitalProject.Repositories.Patients;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public ActionResult Index()
        {
            return View(_patientRepository.GetAll());
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
        public ActionResult Create(PatientsModel patientsModel)
        {
            try
            {
                _patientRepository.AddPatient(patientsModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(patientsModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var patient = _patientRepository.GetById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientsModel patientsModel)
        {
            try
            {
                _patientRepository.EditPatient(patientsModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(patientsModel);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var patient = _patientRepository.GetById(id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PatientsModel patientsModel)
        {
            try
            {
                _patientRepository.DeletePatient(patientsModel.PacienteID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(patientsModel);
            }
        }
    }
}
