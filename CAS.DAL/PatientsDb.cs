using CAS.BOL;
using CAS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.DAL
{
    public interface IPatientsDb
    {
        // 100% Abstractions
        IEnumerable<Patients> GetAll();
        Patients GetById(int id);
        bool Insert(Patients obj);
        bool Update(Patients obj);
        bool Delete(int id);
    }
    public class PatientsDb : IPatientsDb
    {
        // Standard pattern --> Repository
        private AppDbContext context;
        public PatientsDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Patients> GetAll()
        {
            // Add,Update,Remove
            return context.Patients;
        }
        public Patients GetById(int id)
        {
            var obj = context.Patients.Find(id);
            return obj;
        }
        public bool Insert(Patients obj)
        {
            context.Patients.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Patients obj)
        {
            context.Patients.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Patients.Find(id);
            context.Patients.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}

