﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Helpers.VisitHelper
{
    public interface IVisit
    {
        void UpdateVisitBill(int _amount, int VisitId);
    }
}
