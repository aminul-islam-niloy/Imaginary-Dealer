using Imaginary_Dealer.AppDBContex;
using Imaginary_Dealer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imaginary_Dealer.Controllers
{
    public class ModelController : Controller
    {
        public readonly Im_Dealer_DB_Contex _db;
       
        [BindProperty]
      public ModelViewModel ViewModel { get; set; }

        public ModelController(Im_Dealer_DB_Contex db)
        {
            _db = db;
            ViewModel = new ModelViewModel()
            {
                Brands = _db.Brands.ToList(),
                Model = new Models.Model()

            };
        }

        public IActionResult Index()
        {
            var model = _db.Models.Include(m => m.Brand);
            return View(model);
        }

        public IActionResult Create() { 
        return View(ViewModel);
        }
    }
}
