using Microsoft.AspNetCore.Mvc;

namespace CAS.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
