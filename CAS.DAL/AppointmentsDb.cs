using CAS.BOL;
using CAS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.DAL
{
    public interface IAppointmentsDb
    {
        // 100% Abstractions
        IEnumerable<Appointments> GetAll();
        Appointments GetById(int id);
        bool Insert(Appointments obj);
        bool Update(Appointments obj);
        bool Delete(int id);
    }
    public class AppointmentsDb : IAppointmentsDb
    {
        // Standard pattern --> Repository
        private AppDbContext context;
        public AppointmentsDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Appointments> GetAll()
        {
            // Add,Update,Remove
            return context.Appointments;
        }
        public Appointments GetById(int id)
        {
            var obj = context.Appointments.Find(id);
            return obj;
        }
        public bool Insert(Appointments obj)
        {
            context.Appointments.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Appointments obj)
        {
            context.Appointments.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Appointments.Find(id);
            context.Appointments.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}

