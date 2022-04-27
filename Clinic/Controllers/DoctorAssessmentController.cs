using Clinic.Interfaces;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class DoctorAssessmentController : Controller
    {
        private readonly IUnitOfWork<DoctorAssessment> _assessment;
        private readonly MyAppContext _db;
        public DoctorAssessmentController(IUnitOfWork<DoctorAssessment> assessment, MyAppContext db)
        {
            _assessment = assessment;
            _db = db;
        }

        [HttpPost]
        public IActionResult AddAssessment(DoctorAssessment doctorAssessment)
        {
            _assessment.Entity.Add(doctorAssessment);
            _assessment.Save();
            return RedirectToAction("Index","Visit",new { VisitId = doctorAssessment.VisitId });
        }
    }
}
