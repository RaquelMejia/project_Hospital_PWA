using HospitalProject.Models;
using HospitalProject.Repositories.DoctorSpecialty;
using HospitalProject.Repositories.Room;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProject.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomsRepository _roomsRepository;

        public RoomController(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public ActionResult Index()
        {
            return View(_roomsRepository.GetAll());
        }

        // GET: UniverstiyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniverstiyController/Create
        public ActionResult Create()
        {
            ViewBag.DoctorSpecialty = _roomsRepository;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomsModel roomsModel)
        {
            try
            {
                _roomsRepository.AddRoom(roomsModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.DoctorSpecialty = _roomsRepository;

                return View(roomsModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var rooms = _roomsRepository.GetById(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomsModel roomsModel)
        {
            try
            {
                _roomsRepository.EditRoom(roomsModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(roomsModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var rooms = _roomsRepository.GetById(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoomsModel roomsModel)
        {
            try
            {
                _roomsRepository.DeleteRoom(roomsModel.HabitacionID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(roomsModel);
            }
        }
    }
}

