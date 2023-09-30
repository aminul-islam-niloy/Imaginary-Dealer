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
using Microsoft.Extensions.Hosting;

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


        //[HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreatePost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        BikeViewModel.Brands = _db.Brands.ToList();
        //        BikeViewModel.Models = _db.Models.ToList();
        //        return View(BikeViewModel);
        //    }
        //    _db.Bikes.Add(BikeViewModel.Bike);

        //    UploadImageIfAvailable();

        //    _db.SaveChanges();

        //    return RedirectToAction(nameof(Index));
        //}

        //private void UploadImageIfAvailable()
        //{
        //    //Get BikeID we have saved in database            
        //    var BikeID = BikeViewModel.Bike.Id;

        //    //Get wwrootPath to save the file on server
        //    string wwrootPath = _HostingEnvironment.WebRootPath;

        //    //Get the Uploaded files
        //    var files = HttpContext.Request.Form.Files;

        //    //Get the reference of DBSet for the bike we have saved in our database
        //    var SavedBike = _db.Bikes.Find(BikeID);


        //    //Upload the file on server and save the path in database if user have submitted file
        //    if (files.Count != 0)
        //    {
        //        //Extract the extension of submitted file
        //        var Extension = Path.GetExtension(files[0].FileName);
        //        var ImagePath = @"C:\Users\niloy\source\repos\Imaginary Dealer\wwwroot\images\bike\";
        //        //Create the relative image path to be saved in database table 
        //        var RelativeImagePath = ImagePath + BikeID + Extension;

        //        //Create absolute image path to upload the physical file on server
        //        var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);


        //        //Upload the file on server using Absolute Path
        //        using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
        //        {
        //            files[0].CopyTo(filestream);
        //        }

        //        //Set the path in database
        //        SavedBike.ImagePath = RelativeImagePath;
        //    }
        //}








        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]

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
                BikeViewModel.Brands = _db.Brands.ToList();
                BikeViewModel.Models = _db.Models.ToList();
                // Model validation failed, return to the Create view with validation errors
                return View("Create", BikeViewModel);
            }

            _db.Bikes.Add(BikeViewModel.Bike);
            _db.SaveChanges();

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
