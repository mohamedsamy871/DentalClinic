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
        public DoctorAssessmentController(IUnitOfWork<DoctorAssessment> assessment)
        {
            _assessment = assessment;
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
