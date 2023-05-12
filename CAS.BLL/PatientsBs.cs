using CAS.BOL;
using CAS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.BLL
{
    public interface IPatientsBs
    {
        // 100% Abstractions
        IEnumerable<Patients> GetAll();
        Patients GetById(int id);
        bool Insert(Patients obj);
        bool Update(Patients obj);
        bool Delete(int id);
    }
    public class PatientsBs : IPatientsBs
    {
        private readonly IPatientsDb objDb;
        public PatientsBs(IPatientsDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Patients> GetAll()
        {
            return objDb.GetAll();
        }
        public Patients GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Patients obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Patients obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}




