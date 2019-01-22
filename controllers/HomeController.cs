using Microsoft.AspNetCore.Mvc;

namespace testsite.controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}