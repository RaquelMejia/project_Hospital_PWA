using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hospital.Models;
using Hospital.Repositories.Doctores;

namespace Hospital.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly IDoctoresRepository _doctoresRepository;
        private SelectList _hospitalList;

        public DoctoresController(IDoctoresRepository doctoresRepository)
        {
            _doctoresRepository = doctoresRepository;
            _hospitalList = new SelectList(
                                _doctoresRepository.GetAll(),
                                nameof(Doctores.Id),
                                nameof(Doctores.NombreCompleto)
                                  );
        }


        // GET: DoctoresController
        public ActionResult Index()
        {
            return View(_doctoresRepository.GetAll());
        }

        // GET: DoctoresController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctoresController/Create
        public ActionResult Create()
        {
            ViewBag.Hospital = _hospitalList;

            return View();
        }

        // POST: DoctoresController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Doctores doctores)
        {
            try
            {
                _doctoresRepository.Add(doctores);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Hospitales = _hospitalList;
                return View(doctores);
            }
        }

        // GET: DoctoresController/Edit/5
        public ActionResult Edit(int id)
        {
            var doctores = _doctoresRepository.GetById(id);

            _hospitalList = new SelectList(
                            _doctoresRepository.GetAllHospital(),
                            nameof(Hospital.Id),
                            nameof(Hospital.NombreCompleto),
                            hospital?.Hospital?.Id
                            );
            ViewBag.Hospitales = _hospitalList;
            return View(doctores);
        }

        // POST: DoctoresController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hospital hospital)
        {
            try
            {   _doctoresRepository.Edit(doctor);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Hospital = _hospitalList;

                return View(doctor);
            }
        }

        // GET: DoctoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctoresController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
  
}
