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
        [HttpGet]
        public IActionResult CreateorEdit(int id)
        {
            Patients obj = new Patients();
            if(id > 0)
            {
                obj = objPatientsBs.GetById(id);
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult CreateorEdit(Patients model)
        {
            ModelState.Remove("Appointments");
            if(ModelState.IsValid)
            {
                if(model.PId > 0)
                {
                    //Update Patient
                    objPatientsBs.Update(model);
                }
                else
                {
                    //Insert Patient
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
        public IActionResult Details(int id)
        {
            Patients obj = new Patients();
            if (id > 0)
            {
                obj = objPatientsBs.GetById(id);
            }
            return View(obj);

        }
    }
}
