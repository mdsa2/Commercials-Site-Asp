using CM.Data;
using CM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using CM.Roles;
using Microsoft.AspNetCore.Authorization;

namespace CM.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = MyRoles.Role_Admin)]
    public class ProductController1 : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController1(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;  // Corrected assignment
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _db.Products.ToList();
    
            return View(objProductList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj, IFormFile? file)
        {


            obj.CreatedAt = DateTime.Now;


            if (int.TryParse(obj.Name, out _))
            {
                ModelState.AddModelError("Name", "The Product name cannot be a number.");
            }
            if (int.TryParse(obj.Description, out _))
            {
                ModelState.AddModelError("Description", "The Product Description cannot be a number.");
            }
            if (int.TryParse(obj.Author, out _))
            {
                ModelState.AddModelError("Author", "The Product Author cannot be a number.");
            }

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images/product");
                    Directory.CreateDirectory(productPath); // Ensure the directory exists
                    using (var fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImagePath = @"images/product/" + filename;
                }
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Product created successfully.";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Product productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (int.TryParse(obj.Name, out _))
            {
                ModelState.AddModelError("Name", "The Product name cannot be a number.");
            }
            if (int.TryParse(obj.Description, out _))
            {
                ModelState.AddModelError("Description", "The Product Description cannot be a number.");
            }
            if (int.TryParse(obj.Author, out _))
            {
                ModelState.AddModelError("Author", "The Product Author cannot be a number.");
            }
            ViewData["ProductId"]= obj.Id;
            ViewData["ImagePath"]= obj.ImagePath;

            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Product edited successfully.";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product productFromDb = _db.Products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            _db.Products.Remove(productFromDb);
            _db.SaveChanges();
            TempData["Success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
