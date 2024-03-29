﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DoctorAssessment
    {
        public int Id { get; set; }

        [ForeignKey("Visit")]
        public int VisitId { get; set; }
        public VisitInfo Visit { get; set; }

        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string LabTest{ get; set; }


    }
}
