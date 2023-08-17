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
        /*
         * This Method is for displaing all the Cat List on the Frontend to users
         */
        public IActionResult Index()
        {   
            var categoryList = _db.Categories.ToList();
            if (categoryList.Any())
            {
                return View(categoryList);

            }else
                return Content("No Element Found");



        }
        /*
         * This method is for the view page created for the Adding new Categories
         */
        public IActionResult Create() { 
           
                return View();

        }

        /*
         * This is for the POST request made by the previous method
         */

        [HttpPost]
        public IActionResult Create(Category categoryObj)
        {
            /*
             * For checking whether user has added the same parameters
             * for both name and category.
             */
            if(categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Both DisplayOrder and Name cannot have same values:");
            }

            if (categoryObj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("",$"The Name cannot be :\"{categoryObj.Name}\"");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return View();
            }
        }
    }
}
