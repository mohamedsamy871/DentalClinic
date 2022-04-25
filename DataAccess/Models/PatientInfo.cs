using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PatientInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<ClinicSchedule> ClinicSchedules { get; set; }
        public ICollection<VisitInfo> Visits { get; set; }
        public PatientInfo()
        {
            Visits = new Collection<VisitInfo>();
            ClinicSchedules = new Collection<ClinicSchedule>();
        }
    }
}
