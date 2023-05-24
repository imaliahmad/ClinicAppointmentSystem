using CAS.BLL;
using CAS.BOL;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CAS.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientsBs objPatientsBs;

        public PatientsController(IPatientsBs _objPatientsBs)
        {
            objPatientsBs = _objPatientsBs;
        }

        /** 
         * This function is used to get patient list
         **/
        public IActionResult Index()
        {
            try
            {
                var list = objPatientsBs.GetAll();
                return View(list);
            }
            catch(Exception ex)
            {
                var msg=ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["ErrorMessage"]=msg;
                return View();
            }
           
        }

        /** 
         * This function is used to get patient records
         **/

        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            try
            {
                Patients obj = new Patients();
                if (id > 0)
                {
                    obj = objPatientsBs.GetById(id);
                }
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
         * This function is used to create and edit patient records
         **/

        [HttpPost]
        public IActionResult CreateorEdit(Patients model)
        {
            try
            {
                ModelState.Remove("Appointments");
                if (ModelState.IsValid)
                {
                    if (model.PId > 0)
                    {
                        objPatientsBs.Update(model);
                    }
                    else
                    {
                        objPatientsBs.Insert(model);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Patient is not Update/Insert";
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
        * This function is used to get patient details
        **/
        public IActionResult Details(int id)
        {
            try
            {
                Patients obj = new Patients();
                if (id > 0)
                {
                    obj = objPatientsBs.GetById(id);
                }
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
       * This function is used to get patients
       **/
        public JsonResult GetPatients()
        {
            var patients = objPatientsBs.GetAll();
            return Json(patients);
        }

    }
}
