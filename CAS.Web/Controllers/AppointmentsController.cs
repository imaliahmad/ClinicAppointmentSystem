using CAS.BLL;
using CAS.BOL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            Appointments obj = new Appointments();
            if (id > 0)
            {
                obj = objAppointmentsBs.GetById(id);
            }
            // Get Object
            obj.PatientsList = new SelectList(patientsBs.GetAll(), "PId", "Name");
            obj.DoctorsList = new SelectList(doctorsBs.GetAll(), "DId", "Name");
            return View(obj);
        }

        [HttpPost]
        public IActionResult CreateorEdit(Appointments model)
        {
            //remove validation
            if (ModelState.IsValid)
            {
                if (model.AppId > 0)
                {
                    //Update Appointment
                    objAppointmentsBs.Update(model);
                }
                else
                {
                    //Insert Appointment
                    objAppointmentsBs.Insert(model);
                }
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Appointment is not Update/Insert";
                return View(model);
            }
        }
        public IActionResult Details(int id)
        {
            Appointments obj = new Appointments();
            if (id > 0)
            {
                obj = objAppointmentsBs.GetById(id);
            }
            return View(obj);

        }
    }
}


