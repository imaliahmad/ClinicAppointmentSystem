using CAS.BOL;
using CAS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.BLL
{
    public interface IDoctorsBs
    {
        // 100% Abstractions
        IEnumerable<Doctors> GetAll();
        Doctors GetById(int id);
        bool Insert(Doctors obj);
        bool Update(Doctors obj);
        bool Delete(int id);
    }
    public class DoctorsBs : IDoctorsBs
    {
        private readonly IDoctorsDb objDb;
        public DoctorsBs(IDoctorsDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Doctors> GetAll()
        {
            return objDb.GetAll();
        }
        public Doctors GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Doctors obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Doctors obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}


