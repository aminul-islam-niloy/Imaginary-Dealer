using Microsoft.AspNetCore.Mvc;

namespace Imaginary_Dealer.Controllers
{
    public class BikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
