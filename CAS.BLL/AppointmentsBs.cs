using CAS.BOL;
using CAS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.BLL
{
    public interface IAppointmentsBs
    {
        // 100% Abstractions
        IEnumerable<Appointments> GetAll();
        Appointments GetById(int id);
        bool Insert(Appointments obj);
        bool Update(Appointments obj);
        bool Delete(int id);
    }
    public class AppointmentsBs : IAppointmentsBs
    {
        private readonly IAppointmentsDb objDb;
        public AppointmentsBs(IAppointmentsDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<Appointments> GetAll()
        {
            return objDb.GetAll();
        }
        public Appointments GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(Appointments obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(Appointments obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }

        

    }
}




