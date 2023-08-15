using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {   
            var categoryList = _db.Categories.ToList();
            if (categoryList.Any())
            {
                return View(categoryList);

            }else
                return Content("No Element Found");



        }

        public IActionResult Create() { 
           
                return View();

        }
    }
}
