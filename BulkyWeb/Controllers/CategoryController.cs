using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        /*
         * Now Creating Edit Module where we will have two method
         * one for the Edit Page which will be somewhat similar to the Create Page and 
         * Another one for the Post Method which will take the resubmitted data verify it and save it to the database
         */
        public IActionResult Edit(int? CategoryID)
        {
            if (CategoryID == null && CategoryID == 0)
            {
                return NotFound();
            }

            Category? category = _db.Categories.FirstOrDefault(x => x.Id == CategoryID);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        /*
         * This is for the POST request made by the previous method
         */

        [HttpPost]
        public IActionResult Edit(Category categoryObj)
        {
            /*
             * For checking whether user has added the same parameters
             * for both name and category.
             */
            if (categoryObj.Name == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Both DisplayOrder and Name cannot have same values:");
            }

            if (categoryObj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", $"The Name cannot be :\"{categoryObj.Name}\"");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return View();
            }
        }

        /*
         * Creating the DELETE View and DELETE POST Method
         */

        // DELETE GET Method
        public IActionResult Delete(int? CategoryID)
        {
            if (CategoryID == null && CategoryID == 0)
            {
                return NotFound();
            }

            Category? category = _db.Categories.FirstOrDefault(x => x.Id == CategoryID);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

        //DELETE POST Method

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var categoryObj = _db.Categories.Find(id);

            if (categoryObj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Remove(categoryObj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
