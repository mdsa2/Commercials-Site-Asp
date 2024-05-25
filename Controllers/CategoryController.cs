using CM.Data;
using CM.Models;
using CM.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
 
namespace CM.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=MyRoles.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) { 
        _db=db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() {
          
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (int.TryParse(obj.Name, out _))
            {
                ModelState.AddModelError("Name", "The category name cannot be a number.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
              
                _db.SaveChanges();
                TempData["Sucess"] = "category created Succesfully ";
                return RedirectToAction("Index");
            }
          
          return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null) {
            return NotFound();
            }
            Category categoryFrom = _db.categories.Find(id);
            if(categoryFrom == null)
            {
                return NotFound();
            }
            return View(categoryFrom);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (int.TryParse(obj.Name, out _))
            {
                ModelState.AddModelError("Name", "The category name cannot be a number.");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["Sucess"] = "category Edit Succesfully ";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category? categoryFrom = _db.categories.Find(id);
            if (categoryFrom == null)
            {
                return NotFound();
            }
            return View(categoryFrom);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? categoryFrom = _db.categories.Find(id);
            if (categoryFrom == null)
            {
                return NotFound();
            }

            _db.categories.Remove(categoryFrom);
            _db.SaveChanges();
            TempData["Sucess"] = "category Delete Succesfully ";
            return RedirectToAction("Index");


        }
    }
}
  

