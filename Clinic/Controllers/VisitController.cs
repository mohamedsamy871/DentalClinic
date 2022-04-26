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
    public class VisitController : Controller
    {
        private readonly IUnitOfWork<VisitInfo> _visit;
        private readonly MyAppContext _db;
        public VisitController(IUnitOfWork<VisitInfo> visit, MyAppContext db)
        {
            _visit = visit;
            _db = db;
        }
        public IActionResult Index(int PatientId)
        {
            var _patient = _db.Patients.Find(PatientId);
            ViewBag.PatientName = _patient.Name;
            var _patientVisits = _db.Visits.Where(m => m.PatientInfo.Id == PatientId).Include(m=>m.DoctorAssessments).FirstOrDefault();
            return View(_patientVisits);
        }
        public IActionResult AddVisit(int PatientId)
        {
            ViewBag.PatientId = PatientId;
            return View();
        }

        [HttpPost]
        public IActionResult AddVisit(VisitInfo visitInfo)
        {
            visitInfo.Id = 0;
            visitInfo.Date = DateTime.Now.ToString("d");
            visitInfo.Time = DateTime.Now.ToString("t");
            //_visit.Entity.Add(visitInfo);
            _db.Visits.Add(visitInfo);
            _db.SaveChanges();
            return RedirectToAction("Index",new { PatientId = visitInfo.PatientId});
        }
    }
}
