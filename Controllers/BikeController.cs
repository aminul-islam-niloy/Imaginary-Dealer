using Imaginary_Dealer.AppDBContex;
using Imaginary_Dealer.Models;
using Imaginary_Dealer.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace Imaginary_Dealer.Controllers
{
    [Authorize(Roles = "Admin,Excuative")]
    public class BikeController : Controller
    {
        private readonly Im_Dealer_DB_Contex _db;
        private readonly IWebHostEnvironment _HostingEnvironment;


        [BindProperty]
        public BikeViewModelSection BikeViewModel { get; set; }

        public BikeController(Im_Dealer_DB_Contex db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _HostingEnvironment = webHostEnvironment;
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

        [HttpPost, ActionName("Create")]

        public IActionResult CreatePost()
        {
            if (BikeViewModel == null || BikeViewModel.Bike == null)
            {
                // Handle the case where BikeViewModel or Bike is null
                return RedirectToAction("Create");
            }

            // Check if ModelState is valid before proceeding
            if (!ModelState.IsValid)
            {
                // Model validation failed, return to the Create view with validation errors
                return View("Create", BikeViewModel);
            }

            _db.Bikes.Add(BikeViewModel.Bike);

            // Save bike photos in the database
            var BikeID = BikeViewModel.Bike.Id;
            string wwrootPath = _HostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                var ImagePath = @"C:\Users\niloy\source\repos\Imaginary Dealer\wwwroot\images\bike\";
                var Extension = Path.GetExtension(files[0].FileName);
                var RelativeImagePath = ImagePath + BikeID + Extension;

                // Create absolute image path to upload the physical file on the server
                var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

                // Upload the file on the server using Absolute Path
                using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                // Set the path in the database
                var SavedBike = _db.Bikes.Find(BikeID);
                if (SavedBike != null)
                {
                    SavedBike.ImagePath = RelativeImagePath;
                    _db.SaveChanges();
                }
            }

            // Save changes to the database (outside the if block)
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




    //    namespace Imaginary_Dealer.Controllers
    //{
    //    [Authorize(Roles = "Admin,Excuative")]
    //    public class BikeController : Controller
    //    {
    //        private readonly Im_Dealer_DB_Contex _db;
    //        private readonly IWebHostEnvironment _HostingEnvironment;


    //        [BindProperty]
    //        public BikeViewModelSection BikeViewModel { get; set; }

    //        public BikeController(Im_Dealer_DB_Contex db, IWebHostEnvironment webHostEnvironment)
    //        {
    //            _db = db;
    //            _HostingEnvironment = webHostEnvironment;
    //            BikeViewModel = new BikeViewModelSection()
    //            {
    //                Brands = _db.Brands.ToList(),
    //                Models = _db.Models.ToList(),
    //                Bike = new Models.Bike()

    //            };
    //        }

    //        public IActionResult Index()
    //        {
    //            var Bikes = _db.Bikes.Include(m => m.Brand).Include(m => m.Model);
    //            return View(Bikes.ToList());
    //        }

    //        //get method
    //        public IActionResult Create()
    //        {
    //            return View(BikeViewModel);
    //        }

    //        [HttpPost, ActionName("Create")]


    //        public IActionResult CreatePost()
    //        {
    //            //if (!ModelState.IsValid)
    //            //{
    //            //    return View(BikeViewModel);
    //            //}

    //            _db.Bikes.Add(BikeViewModel.Bike);

    //            // Save bike photos in the database
    //            var BikeID = BikeViewModel.Bike.Id;
    //            string wwrootPath = _HostingEnvironment.WebRootPath;
    //            var files = HttpContext.Request.Form.Files;

    //            var SavedBike = _db.Bikes.Find(BikeID);

    //            if (files.Count != 0)
    //            {
    //                var ImagePath = @"C:\Users\niloy\source\repos\Imaginary Dealer\wwwroot\images\bike\";
    //                var Extension = Path.GetExtension(files[0].FileName);
    //                var RelativeImagePath = ImagePath + BikeID + Extension;

    //                // Create absolute image path to upload the physical file on the server
    //                var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

    //                // Upload the file on the server using Absolute Path
    //                using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
    //                {
    //                    files[0].CopyTo(filestream);
    //                }

    //                // Set the path in the database
    //                SavedBike.ImagePath = RelativeImagePath;
    //                _db.SaveChanges();
    //            }

    //            return RedirectToAction("Index");
    //        }


        }
}
