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
    public class ProcedureController : Controller
    {

        private readonly IUnitOfWork<VisitProcedure> _visitProcedures;
        private readonly IUnitOfWork<AllProcedures> _allProcedures;

        public ProcedureController(IUnitOfWork<VisitProcedure> visitProcedures,
            IUnitOfWork<AllProcedures> allProcedures)
        {
            _visitProcedures = visitProcedures;
            _allProcedures = allProcedures;
        }

        [HttpPost]
        public IActionResult AddVisitProcedure(AllProcedures procedureModel,int VisitId, int PatientId)
        {
            var _visitProcedure = new VisitProcedure();
            _visitProcedure.Name = procedureModel.Name;
            _visitProcedure.Amount = procedureModel.Amount;
            _visitProcedure.VisitId = VisitId;
            _visitProcedures.Entity.Add(_visitProcedure);
            _visitProcedures.Save();
            return RedirectToAction("Index","Visit",new { PatientId = PatientId });
        }

        [HttpPost]
        public IActionResult AddProcedure(AllProcedures procedureModel, int PatientId)
        {
            _allProcedures.Entity.Add(procedureModel);
            _allProcedures.Save();
            return RedirectToAction("Index", "Visit", new { PatientId = PatientId });
        }
    }
}
