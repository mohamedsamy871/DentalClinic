using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ClinicSchedule
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public PatientInfo Patient { get; set; }
    }
}
