using Imaginary_Dealer.AppDBContex;
using Imaginary_Dealer.Models;
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

        public IActionResult Create()
        { 
             return View( ViewModel);
        }

        [HttpPost,ActionName("Create")]
        public IActionResult CreatePost(ModelViewModel viewModel) 
        {
            if (ModelState.IsValid)
            {
                return View("Create", ViewModel);
            }
            _db.Models.Add(ViewModel.Model);
            _db.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id) 
        {
            ViewModel.Model = _db.Models.Include(m =>
            m.Brand).SingleOrDefault(m => m.Id == id);
            if (ViewModel.Model == null)
            {
                return NotFound();
            }
            else
            {
                return View(ViewModel);
            }
          

        }

        [HttpPost,ActionName("Edit")]
        public IActionResult EditPost()
        {
            if(ModelState.IsValid)
            {
                return View(ViewModel);
            }

            _db.Update(ViewModel.Model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Model model = _db.Models.Find(id);

            if(model == null)
            {
                return NotFound();  

            }
            _db.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
