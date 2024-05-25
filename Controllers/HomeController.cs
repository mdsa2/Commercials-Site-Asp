using CM.Data;
using CM.Models;
 
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace CM.Controllers
{
    public class HomeController : Controller
    {
     
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

      
        public IActionResult Index()
        {
            try
            {

                var vm = new ProductCategoryViewModel
                {
                    Products = _db.Products.ToList(),
                    Categories = _db.categories.ToList()
                };
                return View(vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while loading the Index view.");
                return View("Error");
            }
        
    }
        public IActionResult Detials(int? id,string imagePath)
        {
            if (id == null)
            {
                return View("Error this page");
            }

            else { 
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
                ViewData["ImagePath"] = product.ImagePath;





                return View(product);
            }



        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
