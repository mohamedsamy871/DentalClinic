using Clinic.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Helpers.VisitHelper
{
    public class VisitHelper : IVisit
    {
        private readonly IUnitOfWork<VisitInfo> _visit;

        public VisitHelper(IUnitOfWork<VisitInfo> visit)
        {
            _visit = visit;
        }
        public void UpdateVisitBill(int _amount, int VisitId)
        {
            var _visitFromDb = _visit.Entity.GetById(VisitId);
            _visitFromDb.TotalBillAmout = _visitFromDb.TotalBillAmout + _amount;
            _visit.Save();
        }
    }
}
