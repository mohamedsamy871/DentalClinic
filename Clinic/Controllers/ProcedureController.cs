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
        private readonly MyAppContext _db;

        public ProcedureController(IUnitOfWork<VisitProcedure> visitProcedures,
            IUnitOfWork<AllProcedures> allProcedures,MyAppContext db)
        {
            _visitProcedures = visitProcedures;
            _allProcedures = allProcedures;
            _db = db;
        }

        [HttpPost]
        public IActionResult AddVisitProcedure(AllProcedures procedureModel,int VisitId)
        {
            var _visitProcedure = new VisitProcedure();
            _visitProcedure.Name = procedureModel.Name;
            _visitProcedure.Amount = procedureModel.Amount;
            _visitProcedure.VisitId = VisitId;
            _visitProcedures.Entity.Add(_visitProcedure);
            _visitProcedures.Save();
            //update bill after adding the procedure
            var _visit = _db.Visits.Find(VisitId);
            _visit.TotalBillAmout = _visit.TotalBillAmout + procedureModel.Amount;
            _db.SaveChanges();
            return RedirectToAction("Index","Visit",new { VisitId = VisitId });
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
