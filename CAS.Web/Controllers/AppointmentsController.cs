using CAS.BLL;
using CAS.BOL;
using CAS.BOL.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CAS.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsBs objAppointmentsBs;
        private readonly IPatientsBs patientsBs;
        private readonly IDoctorsBs doctorsBs;

        public AppointmentsController(IAppointmentsBs _objAppointmentsBs, IPatientsBs _patientsBs, IDoctorsBs _doctorsBs)
        {
            objAppointmentsBs = _objAppointmentsBs;
            patientsBs = _patientsBs;
            doctorsBs = _doctorsBs;
        }

        /** 
         * This function is used to get appointment list
         **/
        public IActionResult Index()
        {
            try
            {
                var list = objAppointmentsBs.GetAll();
                return View(list);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }

        }

        /** 
         * This function is used to get appointment records
         **/

        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            try
            {
                Appointments obj = new Appointments();
                obj.AppStatus = AppStatusTypes.Pending;
                obj.FeeStatus = FeeStatusTypes.Unpaid;

                if (id > 0)
                {
                    obj = objAppointmentsBs.GetById(id);
                }


                obj.PatientsList = new SelectList(
                                            patientsBs.GetAll(), "PId", "Name");

                obj.DoctorsList = new SelectList(
                                            doctorsBs.GetAll(), "DId", "Name");
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
           
        }
        /** 
         * This function is used to create and edit appointment recordsB
         **/
        [HttpPost]
        public IActionResult CreateorEdit(Appointments model)
        {
            try
            {
                ModelState.Remove("AppNo");
                ModelState.Remove("AppStatus");
                ModelState.Remove("FeeStatus");
                if (ModelState.IsValid)
                {
                    if (model.AppId > 0)
                    {

                        objAppointmentsBs.Update(model);
                    }
                    else
                    {
                        objAppointmentsBs.Insert(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage);
                    TempData["ErrorMessage"] = "Appointment is not Update/Insert";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();
            }
        }

        /** 
       * This function is used to get appointment details
       **/
        public IActionResult Details(int id)
        {
            try
            {
                Appointments obj = new Appointments();
                obj.AppStatus = AppStatusTypes.Pending;
                obj.FeeStatus = FeeStatusTypes.Unpaid;

                if (id > 0)
                {
                    obj = objAppointmentsBs.GetById(id);
                }


                obj.PatientsList = new SelectList(
                                            patientsBs.GetAll(), "PId", "Name");

                obj.DoctorsList = new SelectList(
                                            doctorsBs.GetAll(), "DId", "Name");
                return View(obj);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"] = msg;
                return View();

            }

        }

        /** 
        * This function is used to get appointments
        **/
        public JsonResult GetAppointments()
        {
            var doctors = objAppointmentsBs.GetAll();
            return Json(doctors);
        }

    }
}


