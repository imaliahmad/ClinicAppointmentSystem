using CAS.BOL;
using CAS.DAL.Data;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var list = context.Appointments
                          .Include(p => p.Patients)
                          .Include(d => d.Doctors)
                          .Select(x => new Appointments()
                          {
                              AppId = x.AppId,
                              AppNo= x.AppNo,
                              PId = x.PId,
                              Patients = x.Patients,
                              DId = x.DId,
                              Doctors = x.Doctors,
                              DateTime= x.DateTime,
                              DrFee= x.DrFee,
                              Discount=x.Discount,
                              BillAmt=x.BillAmt,
                              FeeStatus= x.FeeStatus,
                              AppStatus= x.AppStatus,

                          }).ToList();

            return list;
        }
        public Appointments GetById(int id)
        {
            var obj = context.Appointments.Find(id);
            return obj;
        }
        public bool Insert(Appointments obj)
        {
            obj.AppNo = GetUniqueAppointmentNumber(); //AP-210523-0002
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

        //GetUniqueAppointmentNumber ==> AP-200523-0005
        public string GetUniqueAppointmentNumber()
        {
            string appointment = "AP";
            string currentDate = DateTime.Now.ToString("ddMMyy");

            string latestAppointmentNumber = context.Appointments
                                                    .Where(a => a.AppNo.StartsWith(appointment + "-" + currentDate))
                                                    .OrderByDescending(a => a.AppNo)
                                                    .Select(a => a.AppNo)
                                                    .FirstOrDefault();


            //string latestAppointmentNumber = context.Appointments
            //                                        .OrderByDescending(x => x.AppNo)
            //                                        .FirstOrDefault()
            //                                        .AppNo;

            // D4 = 0000

            int sequenceNumber = 1;
            if (!string.IsNullOrEmpty(latestAppointmentNumber))
            { 
                string sequencePart = latestAppointmentNumber.Substring(10,4); // 0005 
                sequenceNumber = Convert.ToInt32(sequencePart) + 1; //6
            }
            // string.format("", D4)

                string newAppointmentNumber = $"{appointment}-{currentDate}-{sequenceNumber:D4}";
                return newAppointmentNumber;

        }
       







            //string result = "";

        ////if (appiontment exist in database)
        ////{ 
        ////    //AP-210523-0006
        ////    //split
        ////}
        ////else
        ////{
        ////   // 0001
        ////}


        //return "";
        }
}


