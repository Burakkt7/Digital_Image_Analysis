using Microsoft.AspNetCore.Mvc;

namespace Digital_Image_Analysis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
