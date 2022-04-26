using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class VisitProcedure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        [ForeignKey("Visit")]
        public int VisitId { get; set; }

        public VisitInfo Visit { get; set; }
    }
}
