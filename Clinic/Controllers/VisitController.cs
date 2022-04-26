using Clinic.Interfaces;
using Clinic.ViewModels;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
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
            var patient = _db.Patients.Find(PatientId);
            var patientVisits = _db.Visits.Where(m => m.PatientInfo.Id == PatientId).FirstOrDefault();
            var Bill = _db.PatientBills.Where(m => m.Visit.Id == patientVisits.Id).FirstOrDefault();

            var VisitDetails = new VisitViewModel() {
                PatientInfo = patient,
                VisitInfo =patientVisits,
                PatientBill =Bill
            };

            return View(_visit.Entity.GetAll());
        }

        public IActionResult AddVisit(int PatientId)
        {
            ViewBag.PatientId = PatientId;
            return View();
        }
        [HttpPost]
        public IActionResult AddVisit(VisitInfo visitInfo)
        {
            visitInfo.Date = DateTime.Now.ToString("d");
            visitInfo.Time = DateTime.Now.ToString("t");
            _visit.Entity.Add(visitInfo);
            _visit.Save();
            return RedirectToAction("Index");
        }
    }
}
