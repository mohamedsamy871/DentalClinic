using Clinic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork<ClinicSchedule> _schedule;
        public AppointmentController(IUnitOfWork<ClinicSchedule> schedule)
        {
            _schedule = schedule;
        }
        public IActionResult AddAppointment(int id)
        {
            ViewBag.PatientId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointment(ClinicSchedule _appintment)
        {
            _appintment.Id = 0;
            _schedule.Entity.Add(_appintment);
            _schedule.Save();
            return RedirectToAction("Index", "Patient");
        }
    }
}
