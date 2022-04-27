using Clinic.Helpers.VisitHelper;
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
        private readonly IVisit _visitHelper;

        public ProcedureController(IUnitOfWork<VisitProcedure> visitProcedures,
            IUnitOfWork<AllProcedures> allProcedures,IVisit visitHelper)
        {
            _visitProcedures = visitProcedures;
            _allProcedures = allProcedures;
            _visitHelper = visitHelper;
        }
        //to Add a clinic procedure to a known visit
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
            _visitHelper.UpdateVisitBill(procedureModel.Amount, VisitId);

            return RedirectToAction("Index","Visit",new { VisitId = VisitId });
        }
        //to fill the clinic procedure table
        [HttpPost]
        public IActionResult AddProcedure(AllProcedures procedureModel, int PatientId)
        {
            _allProcedures.Entity.Add(procedureModel);
            _allProcedures.Save();
            return RedirectToAction("Index", "Visit", new { PatientId = PatientId });
        }

    }
}
