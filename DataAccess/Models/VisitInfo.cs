using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{ 
    public class VisitInfo
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        [ForeignKey("BillId")]
        public PatientBill Bill { get; set; }

        public VisitType Type { get; set; }

        public ICollection<DoctorAssessment> DoctorAssessments { get; set; }


        [ForeignKey("PatientId")]
        public PatientInfo PatientInfo { get; set; }

        public enum VisitType
        {
            Examination, Consultation
        }

        public VisitInfo()
        {
            DoctorAssessments = new Collection<DoctorAssessment>();
            
        }
    }
     
}
