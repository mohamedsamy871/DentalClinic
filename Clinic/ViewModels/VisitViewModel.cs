using DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataAccess.Models.VisitInfo;

namespace Clinic.ViewModels
{
    public class VisitViewModel
    {
        public ICollection<DoctorAssessment> DoctorAssessments { get; set; }
        public PatientInfo PatientInfo { get; set; }
        public PatientBill PatientBill { get; set; }
        public VisitInfo VisitInfo { get; set; }
        public VisitType Type { get; set; }
        public List<SelectListItem> VisitTypes { get; set; }
        public VisitViewModel()
        {
            VisitTypes = new List<SelectListItem>();
            VisitTypes.Add(new SelectListItem { 
                Value= ((int)VisitType.Consultation).ToString(),
                Text = VisitType.Consultation.ToString()
            });;
            VisitTypes.Add(new SelectListItem
            {
                Value = ((int)VisitType.Examination).ToString(),
                Text = VisitType.Examination.ToString()
            }); ;
        }
    }
}
