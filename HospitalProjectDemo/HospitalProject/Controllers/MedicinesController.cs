using HospitalProject.Models;
using HospitalProject.Repositories.DoctorSpecialty;
using HospitalProject.Repositories.Medicines;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly IMedicinesRepository _medicinesRepository;

        public MedicinesController(IMedicinesRepository medicinesRepository)
        {
            this._medicinesRepository = medicinesRepository;
        }

        public ActionResult Index()
        {
            return View(_medicinesRepository.GetAll());
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
        public ActionResult Create(MedicinesModel medicinesModel)
        {
            try
            {
                _medicinesRepository.AddMedicines(medicinesModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

                return View(medicinesModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var medicines = _medicinesRepository.GetById(id);

            if (medicines == null)
            {
                return NotFound();
            }

            return View(medicines);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicinesModel medicinesModel)
        {
            try
            {
                _medicinesRepository.EditMedicines(medicinesModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(medicinesModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var medicines = _medicinesRepository.GetById(id);

            if (medicines == null)
            {
                return NotFound();
            }

            return View(medicines);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MedicinesModel medicinesModel)
        {
            try
            {
                _medicinesRepository.DeleteMedicines(medicinesModel.MedicamentoID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(medicinesModel);
            }
        }
    }
}
