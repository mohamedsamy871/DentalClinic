using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class MyAppContext:DbContext
    {
        public MyAppContext(DbContextOptions options ):base(options){
            
        }

        public DbSet<PatientInfo> Patients { get; set; }
        public DbSet<VisitInfo> Visits { get; set; }
        public DbSet<ClinicSchedule> ClinicSchedules { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
    }
}
