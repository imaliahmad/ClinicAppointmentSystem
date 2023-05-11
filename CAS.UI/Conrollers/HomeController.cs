using Microsoft.AspNetCore.Mvc;

namespace CAS.UI.Conrollers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
