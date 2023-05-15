using CAS.BLL;
using CAS.BOL;
using Microsoft.AspNetCore.Mvc;

namespace CAS.Web.Controllers
{
    //Exception Handling
    public class DoctorsController : Controller
    {
        private readonly IDoctorsBs objDoctorsBs;
        public DoctorsController(IDoctorsBs _objDoctorsBs)
        {
            objDoctorsBs = _objDoctorsBs;
        }
        public IActionResult Index()
        {
            try
            {                
                var list = objDoctorsBs.GetAll();
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
                Doctors obj = new Doctors();

                if (id > 0)
                {
                    obj = objDoctorsBs.GetById(id);
                }
                return View(obj);
        }
        [HttpPost]
        public IActionResult CreateorEdit(Doctors model)
        {
            ModelState.Remove("Appointments");
            if(ModelState.IsValid)
            { 
               
                if (model.DId > 0)
                {
                    // Update Doctor
                    objDoctorsBs.Update(model);
                }               
                else
                {
                    //Insert Doctor
                    objDoctorsBs.Insert(model);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Doctor is not Update/Insert";
                return View(model);
            }
        }
        public IActionResult Details(int id)
        {           
                Doctors obj = new Doctors();

                if (id > 0)
                {
                    obj = objDoctorsBs.GetById(id);
                }
                return View(obj);
           
        }

    }
}


