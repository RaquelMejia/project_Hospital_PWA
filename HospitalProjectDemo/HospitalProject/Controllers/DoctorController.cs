using HospitalProject.Models;
using HospitalProject.Repositories.Doctor;
using HospitalProject.Repositories.DoctorSpecialty;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace HospitalProject.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private SelectList _doctorSpecialtyList;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;

            _doctorSpecialtyList = new SelectList(_doctorRepository.GetAllSpecialty(), 
                                              nameof(DoctorSpecialtyModel.EspecialidadID), 
                                              nameof(DoctorSpecialtyModel.NombreEspecialidad));
        }

        public ActionResult Index()
        {
            return View(_doctorRepository.GetAll());
        }

        // GET: UniverstiyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniverstiyController/Create
        public ActionResult Create()
        {
            ViewBag.DoctorSpecialty = _doctorSpecialtyList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorsModel doctorsModel)
        {
            try
            {
                _doctorRepository.AddDoctor(doctorsModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.DoctorSpecialty = _doctorSpecialtyList;

                return View(doctorsModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var doctor = _doctorRepository.GetById(id);

            _doctorSpecialtyList = new SelectList(_doctorRepository.GetAllSpecialty(),
                                              nameof(DoctorSpecialtyModel.EspecialidadID),
                                              nameof(DoctorSpecialtyModel.NombreEspecialidad),
                                              doctor?.Especialidades?.EspecialidadID);

            ViewBag.DoctorSpecialty = _doctorSpecialtyList;

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorsModel doctorsModel)
        {
            try
            {
                _doctorRepository.EditDoctor(doctorsModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.DoctorSpecialty = _doctorSpecialtyList;

                return View(doctorsModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var doctor = _doctorRepository.GetById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var specialty = _doctorRepository.GetAllSpecialty();

            doctor.Especialidades = specialty.FirstOrDefault(r => r.EspecialidadID == doctor.EspecialidadID);

            return View(doctor);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DoctorsModel doctorsModel)
        {
            try
            {
                _doctorRepository.DeleteDoctor(doctorsModel.DoctorID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(doctorsModel);
            }
        }
    }
}
