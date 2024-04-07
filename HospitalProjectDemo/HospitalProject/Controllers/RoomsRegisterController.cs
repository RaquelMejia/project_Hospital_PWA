using HospitalProject.Models;
using HospitalProject.Repositories.Doctor;
using HospitalProject.Repositories.RoomsRegisters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalProject.Controllers
{
    public class RoomsRegisterController : Controller
    {
        private readonly IRoomsRegistersRepository  _roomsRegistersRepository;
        private SelectList _roomsList;
        private SelectList _patientsList;

        public RoomsRegisterController(IRoomsRegistersRepository roomsRegistersRepository)
        {
            _roomsRegistersRepository = roomsRegistersRepository;

            _roomsList = new SelectList(_roomsRegistersRepository.GetAllRooms(),
                                  nameof(RoomsModel.HabitacionID),
                                  nameof(RoomsModel.NumeroHabitacion));

            _patientsList = new SelectList(_roomsRegistersRepository.GetAllPatients(),
                                  nameof(PatientsModel.PacienteID),
                                  nameof(PatientsModel.NombreCompleto));
        }

        public ActionResult Index()
        {
            return View(_roomsRegistersRepository.GetAll());
        }

        // GET: UniverstiyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniverstiyController/Create
        public ActionResult Create()
        {
            ViewBag.Rooms = _roomsList;
            ViewBag.Patients = _patientsList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomsRegistrationsModel roomsRegistrationsModel)
        {
            try
            {
                _roomsRegistersRepository.AddRoomRegister(roomsRegistrationsModel);

                TempData["message"] = "Datos guardados exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Rooms = _roomsList;
                ViewBag.Patients = _patientsList;

                return View(roomsRegistrationsModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var room = _roomsRegistersRepository.GetById(id);

            _roomsList = new SelectList(_roomsRegistersRepository.GetAllRooms(),
                                        nameof(RoomsModel.HabitacionID),
                                        nameof(RoomsModel.NumeroHabitacion),
                                        room?.NumeroHabitacion?.HabitacionID);

            _patientsList = new SelectList(_roomsRegistersRepository.GetAllPatients(),
                                           nameof(PatientsModel.PacienteID),
                                           nameof(PatientsModel.NombreCompleto),
                                           room?.NombrePaciente?.PacienteID);

            ViewBag.Rooms = _roomsList;
            ViewBag.Patients = _patientsList;

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomsRegistrationsModel roomsRegistrationsModel)
        {
            try
            {
                _roomsRegistersRepository.EditRoomRegister(roomsRegistrationsModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Rooms = _roomsList;
                ViewBag.Patients = _patientsList;

                return View(roomsRegistrationsModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var room = _roomsRegistersRepository.GetById(id);

            if (room == null)
            {
                return NotFound();
            }

            var rooms = _roomsRegistersRepository.GetAllRooms();
            var pacient = _roomsRegistersRepository.GetAllPatients();

            room.NumeroHabitacion = rooms.FirstOrDefault(r => r.HabitacionID == room.HabitacionID);
            room.NombrePaciente = pacient.FirstOrDefault(p => p.PacienteID == room.PacienteID);

            return View(room);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RoomsRegistrationsModel roomsRegistrationsModel)
        {
            try
            {
                _roomsRegistersRepository.DeleteRoomRegister(roomsRegistrationsModel.RegistroHabitacionID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(roomsRegistrationsModel);
            }
        }
    }
}