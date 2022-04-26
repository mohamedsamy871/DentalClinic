using Clinic.Interfaces;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class PatientController : Controller
    {

        private readonly IUnitOfWork<PatientInfo> _patient;
        private readonly MyAppContext _db;

        public PatientController(IUnitOfWork<PatientInfo> patient,MyAppContext db)
        {
            _patient = patient;
            _db = db;
        }
        public IActionResult Index()
        {
            var _clinicSchedule = _db.Patients.Include(m => m.ClinicSchedules).Include(m=>m.Visits).ToList();
            return View(_clinicSchedule);
        }

        public IActionResult GetPatient(int id)
        {
            var _patientDetails = _patient.Entity.GetById(id);
            return View(_patientDetails);
        }

        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(PatientInfo patient)
        {
            _patient.Entity.Add(patient);
            _patient.Save();
            return RedirectToAction("Index");
        }

        public IActionResult DeletePatient(int id)
        {
            _patient.Entity.Delete(id);
            _patient.Save();
            return RedirectToAction("Index");
        }
    }
}
