using HospitalProject.Models;
using HospitalProject.Repositories.DoctorSpecialty;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class DoctorSpecialtyController : Controller
    {
        private readonly IDoctorSpecialtyRepository _doctorSpecialtyRepository;

        public DoctorSpecialtyController(IDoctorSpecialtyRepository doctorSpecialtyRepository)
        {
            _doctorSpecialtyRepository = doctorSpecialtyRepository;
        }

        public ActionResult Index()
        {
            return View(_doctorSpecialtyRepository.GetAll());
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
        public ActionResult Create(DoctorSpecialtyModel doctorSpecialtyModel)
        {
            try
            {
                _doctorSpecialtyRepository.AddDoctorSpecialty(doctorSpecialtyModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(doctorSpecialtyModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var doctorSpecialty = _doctorSpecialtyRepository.GetById(id);

            if (doctorSpecialty == null)
            {
                return NotFound();
            }

            return View(doctorSpecialty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorSpecialtyModel doctorSpecialtyModel)
        {
            try
            {
                _doctorSpecialtyRepository.EditDoctorSpecialty(doctorSpecialtyModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(doctorSpecialtyModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var doctorSpecialty = _doctorSpecialtyRepository.GetById(id);

            if (doctorSpecialty == null)
            {
                return NotFound();
            }

            return View(doctorSpecialty);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DoctorSpecialtyModel doctorSpecialtyModel)
        {
            try
            {
                _doctorSpecialtyRepository.DeleteDoctorSpecialty(doctorSpecialtyModel.EspecialidadID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(doctorSpecialtyModel);
            }
        }
    }
}
