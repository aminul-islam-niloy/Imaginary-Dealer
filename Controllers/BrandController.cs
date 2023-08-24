using Microsoft.AspNetCore.Mvc;
using Imaginary_Dealer.Models;
using Imaginary_Dealer.AppDBContex;

namespace Imaginary_Dealer.Controllers
{
    public class BrandController : Controller
    {
        public readonly Im_Dealer_DB_Contex _db;

        public BrandController(Im_Dealer_DB_Contex db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            return View(_db.Brands.ToList());
        }

        //HTTP get Method
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
		public IActionResult Create(Brand brand)
		{

            if(ModelState.IsValid)
            { 
                _db.Brands.Add(brand);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(brand);
			
		}
		//brands/bikes
		public IActionResult Bikes()
        {


            return View();
        }
    }
}
