using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
        public int VisitAmout { get; set; }
        public int TotalBillAmout { get; set; }
        public ICollection<Procedure> Procedures { get; set; }
        [EnumDataType(typeof(VisitType))]
        public VisitType Type { get; set; }
        public ICollection<DoctorAssessment> DoctorAssessments { get; set; }

        [ForeignKey("PatientInfo")]
        public int PatientId { get; set; }
        public PatientInfo PatientInfo { get; set; }

        public enum VisitType
        {
            [Display(Name = "Examination")]
            Examination,

            [Display(Name = "Consultation")]
            Consultation
        }

        public VisitInfo()
        {
            DoctorAssessments = new Collection<DoctorAssessment>();
            Procedures = new Collection<Procedure>();
        }
    }
     
}
