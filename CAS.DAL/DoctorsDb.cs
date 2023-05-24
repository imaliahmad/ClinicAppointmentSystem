using CAS.BOL;
using CAS.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.DAL
{
    public interface IDoctorsDb
    {
        // 100% Abstractions
        IEnumerable<Doctors> GetAll();
        Doctors GetById(int id);
        bool Insert(Doctors obj);
        bool Update(Doctors obj);
        bool Delete(int id);
        decimal GetDrFee(int id);
    }
    public class DoctorsDb : IDoctorsDb
    {
        // Standard pattern --> Repository
        private AppDbContext context;
        public DoctorsDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<Doctors> GetAll()
        {
            // Add,Update,Remove
            
            return context.Doctors.ToList();
        }
        public Doctors GetById(int id)
        {
            var obj = context.Doctors.Find(id);
            return obj;
        }
        public bool Insert(Doctors obj)
        {   
            context.Doctors.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(Doctors obj)
        {
            context.Doctors.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.Doctors.Find(id);
            context.Doctors.Remove(obj);
            context.SaveChanges();
            return true;
        }
       
        public decimal GetDrFee(int id)
        {
            var obj = context.Doctors.Where(x => x.DId == id).FirstOrDefault();
            return obj.DrFee;
        }
       

       
    }
}

