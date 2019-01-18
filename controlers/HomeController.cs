using Microsoft.AspNetCore.Mvc;

namespace mysite.controlers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}