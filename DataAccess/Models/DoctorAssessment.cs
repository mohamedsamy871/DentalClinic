using System;
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

        [ForeignKey("VisitId")]
        public VisitInfo Visit { get; set; }

        public string Diagnosis { get; set; }
        public string Prescription { get; set; }
        public string LabTest{ get; set; }


    }
}
