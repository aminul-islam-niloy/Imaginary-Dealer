using Imaginary_Dealer.AppDBContex;
using Imaginary_Dealer.Models;
using Imaginary_Dealer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imaginary_Dealer.Controllers
{
    [Authorize(Roles = "Admin,Excuative")]
    public class BikeController : Controller
    {
        public readonly Im_Dealer_DB_Contex _db;

        [BindProperty]
        public BikeViewModelSection BikeViewModel { get; set; }

        public BikeController(Im_Dealer_DB_Contex db)
        {
            _db = db;
            BikeViewModel = new BikeViewModelSection()
            {
                Brands = _db.Brands.ToList(),
                Models = _db.Models.ToList(),
                Bike = new Models.Bike()

            };
        }

        public IActionResult Index()
        {
            var Bikes = _db.Bikes.Include(m => m.Brand).Include(m => m.Model);
            return View(Bikes.ToList());
        }

        //get method
        public IActionResult Create()
        {
            return View(BikeViewModel);
        }

        //post method
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]

        public IActionResult CreatePost()
        {
            if (ModelState.IsValid)
            {
                return View(BikeViewModel);
            }
            _db.Bikes.Add(BikeViewModel.Bike);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        //public IActionResult Edit(int id)
        //{
        //    ViewModel.Model = _db.Models.Include(m =>
        //    m.Brand).SingleOrDefault(m => m.Id == id);
        //    if (ViewModel.Model == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return View(ViewModel);
        //    }


        //}

        //[HttpPost, ActionName("Edit")]
        //public IActionResult EditPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View(ViewModel);
        //    }

        //    _db.Update(ViewModel.Model);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    Model model = _db.Models.Find(id);

        //    if (model == null)
        //    {
        //        return NotFound();

        //    }
        //    _db.Remove(model);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");

        //}


    }
}
