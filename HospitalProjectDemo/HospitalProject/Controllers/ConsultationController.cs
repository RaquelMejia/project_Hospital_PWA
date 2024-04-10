using HospitalProject.Models;
using HospitalProject.Repositories.Consultation;
using HospitalProject.Repositories.RoomsRegisters;
using HospitalProject.Services.Email;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalProject.Controllers
{
    public class ConsultationController : Controller
    {
        private readonly IConsultationsRepository _consultationsRepository;
        private readonly IEmailService _emailService;
        private SelectList _patientList;
        private SelectList _doctorList;
        private SelectList _medicinesList;

        public ConsultationController(IConsultationsRepository consultationsRepository, IEmailService emailService)
        {
            _consultationsRepository = consultationsRepository;
            _emailService = emailService;

            _patientList = new SelectList(_consultationsRepository.GetAllPatients(),
                      nameof(PatientsModel.PacienteID),
                      nameof(PatientsModel.NombreCompleto));

            _doctorList = new SelectList(_consultationsRepository.GetAllDoctors(),
                      nameof(DoctorsModel.DoctorID),
                      nameof(DoctorsModel.NombreCompleto));

            _medicinesList = new SelectList(_consultationsRepository.GetAllMedicines(),
                      nameof(MedicinesModel.MedicamentoID),
                      nameof(MedicinesModel.Nombre));
        }

        public ActionResult Index()
        {
            return View(_consultationsRepository.GetAll());
        }

        // GET: UniverstiyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniverstiyController/Create
        public ActionResult Create()
        {
            ViewBag.Patients = _patientList;
            ViewBag.Doctors = _doctorList;
            ViewBag.Medicines = _medicinesList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultationModel consultationModel)
        {
            try
            {
                _consultationsRepository.AddConsultations(consultationModel);

                TempData["message"] = "Datos guardados exitosamente";

                string email = "hospital@gmail.com";
                string subject = "Resultado de Consulta";
                string body = "Resultado de Consulta jajajajja";

                _emailService.SendEmail(email, "Williams", subject, body);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Patients = _patientList;
                ViewBag.Doctors = _doctorList;
                ViewBag.Medicines = _medicinesList;

                return View(consultationModel);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var consultation = _consultationsRepository.GetById(id);

            _patientList = new SelectList(_consultationsRepository.GetAllPatients(),
                                        nameof(PatientsModel.PacienteID),
                                        nameof(PatientsModel.NombreCompleto),
                                        consultation?.Pacientes?.PacienteID);

            _doctorList = new SelectList(_consultationsRepository.GetAllDoctors(),
                                        nameof(DoctorsModel.DoctorID),
                                        nameof(DoctorsModel.NombreCompleto),
                                        consultation?.Doctores?.DoctorID);

            _medicinesList = new SelectList(_consultationsRepository.GetAllMedicines(),
                            nameof(MedicinesModel.MedicamentoID),
                            nameof(MedicinesModel.Nombre),
                            consultation?.Medicinas?.MedicamentoID);

            ViewBag.Patients = _patientList;
            ViewBag.Doctors = _doctorList;
            ViewBag.Medicines = _medicinesList;

            if (consultation == null)
            {
                return NotFound();
            }

            return View(consultation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsultationModel consultationModel)
        {
            try
            {
                _consultationsRepository.EditConsultations(consultationModel);

                TempData["message"] = "Datos editados correctamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Patients = _patientList;
                ViewBag.Doctors = _doctorList;
                ViewBag.Medicines = _medicinesList;

                return View(consultationModel);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var consultation = _consultationsRepository.GetById(id);

            if (consultation == null)
            {
                return NotFound();
            }

            var pacient = _consultationsRepository.GetAllPatients();
            var doctors = _consultationsRepository.GetAllDoctors();
            var medicines = _consultationsRepository.GetAllMedicines();

            consultation.Pacientes = pacient.FirstOrDefault(p => p.PacienteID == consultation.PacienteID);
            consultation.Doctores = doctors.FirstOrDefault(r => r.DoctorID == consultation.DoctorID);
            consultation.Medicinas = medicines.FirstOrDefault(p => p.MedicamentoID == consultation.PacienteID);

            return View(consultation);
        }

        // POST: UniverstiyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ConsultationModel consultationModel)
        {
            try
            {
                _consultationsRepository.DeleteConsultations(consultationModel.ConsultaID);

                TempData["message"] = "Dato eliminado exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(consultationModel);
            }
        }
    }
}
