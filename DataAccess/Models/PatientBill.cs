using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PatientBill
    {
        public int Id { get; set; }
        public int VisitAmout { get; set; }
        public int TotalAmout { get; set; }


        public VisitInfo Visit { get; set; }
        public ICollection<Procedure> Procedures { get; set; }
        public PatientBill()
        {
            Procedures = new Collection<Procedure>();
        }
    }
}
