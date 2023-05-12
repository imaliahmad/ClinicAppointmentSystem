using CAS.BLL;
using CAS.BOL;
using Microsoft.AspNetCore.Mvc;

namespace CAS.Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorsBs objDoctorsBs;
        public DoctorsController(IDoctorsBs _objDoctorsBs)
        {
            objDoctorsBs = _objDoctorsBs;
        }
        public IActionResult Index()
        {
            var list = objDoctorsBs.GetAll();
            return View(list);
        }
        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            TempData["ErrorMessage"] = null;

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
                // Update Doctor
                if (model.DId > 0)
                {
                    objDoctorsBs.Update(model);
                }
                //Insert Doctor
                else
                {
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


