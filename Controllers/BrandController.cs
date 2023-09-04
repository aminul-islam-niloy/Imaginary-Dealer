using Microsoft.AspNetCore.Mvc;
using Imaginary_Dealer.Models;
using Imaginary_Dealer.AppDBContex;
using Microsoft.AspNetCore.Authorization;

namespace Imaginary_Dealer.Controllers
{
    [Authorize(Roles = "Admin,Excuative")]
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
          var brand= _db.Brands.Find(id);
            if(brand == null)
            {
                return NotFound();
            }
            _db.Brands.Remove(brand);
            _db.SaveChanges();
            return RedirectToAction("Index");   

        }

        public IActionResult Edit(int id)
        {
            var brand = _db.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
        
            return View(brand);

        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {

            if (ModelState.IsValid)
            {
                _db.Brands.Update(brand);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);

        }


    
    }
}
