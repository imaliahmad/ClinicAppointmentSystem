using CAS.BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.DAL
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=ClinicAppointmentSystem;Trusted_Connection=True");
        }

        //Db Set

        public DbSet<Department> Department { get; set; }
    }
}


