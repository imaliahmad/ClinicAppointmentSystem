using CAS.BLL;
using CAS.BOL;
using CAS.BOL.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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

        /** 
         * This function is used to get doctor list
         **/
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

        /** 
         * This function is used to get doctor records
         **/

        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            try
            {
                Doctors obj = new Doctors();
                if (id > 0)
                {
                    obj = objDoctorsBs.GetById(id);
                }

                obj.DegreeList = new SelectList(Enum.GetValues(typeof(DegreeTypes)));
                obj.SpeciallityList = new SelectList(Enum.GetValues(typeof(SpeciallityTypes)));
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
         * This function is used to create and edit doctor records
         **/

        [HttpPost]
        public IActionResult CreateorEdit(Doctors model)
        {
            try
            {
                ModelState.Remove("Appointments");
                if (ModelState.IsValid)
                {
                    if (model.DId > 0)
                    {
                        objDoctorsBs.Update(model);
                    }
                    else
                    {
                        objDoctorsBs.Insert(model);
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage);
                    TempData["ErrorMessage"] = "Doctor is not Update/Insert";
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
        * This function is used to get doctor detail
        **/
        public IActionResult Details(int id)
        {
            try
            {
                Doctors obj = new Doctors();
                if (id > 0)
                {
                    obj = objDoctorsBs.GetById(id);
                }
                obj.DegreeList = new SelectList(Enum.GetValues(typeof(DegreeTypes)));
                obj.SpeciallityList = new SelectList(Enum.GetValues(typeof(SpeciallityTypes)));
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
        * This function is used to get dr fee
        **/
        public JsonResult GetDrFee(int id)
        {
            var fee = objDoctorsBs.GetDrFee(id);
            return Json(fee);
        }
       /** 
       * This function is used to get doctors
       **/
        public JsonResult GetDoctors()
        {
            var doctors = objDoctorsBs.GetAll();
            return Json(doctors);
        }


    }
}


