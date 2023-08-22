using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext db)
        {
            _context = db;
        }
        
            
        
        public IActionResult Index()
        {
            List<Category> categories = _context.category.ToList();

            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category _category)
        {
            if (_category.Name == _category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name","The Category name and Display Order can not be same");
            }

            if(ModelState.IsValid)
            {
                _context.category.Add(_category);
                _context.SaveChanges();
                TempData["success"] = "Category added successfully";

                return RedirectToAction("index");

            }

            return View();  
           
        }

        public IActionResult Edit(int id)
        {
            Category categoryId = _context.category.FirstOrDefault(x => x.Id == id);
            if (categoryId == null) {
            
                return NotFound();
            }

            return View(categoryId);
        }

        [HttpPost]
        public IActionResult Edit(Category _category)
        {
            if(ModelState.IsValid)
            {
                _context.category.Update(_category);
                _context.SaveChanges();
            }
            TempData["success"] = "Category updated successfully";

            return RedirectToAction("Index");   
        }


        public IActionResult Delete(int id)
        {
            var category = _context.category.FirstOrDefault(y => y.Id == id);

            if(category != null)
            {

                return View(category);
            }

            return View(category);
        }


        [HttpPost]
        public IActionResult Delete(Category _category)
        {
            var categoryId = _context.category.FirstOrDefault(x => x.Id == _category.Id);

            if(categoryId != null)
            {
                _context.category.Remove(categoryId);
                _context.SaveChanges();
                TempData["success"] = "Category deleted successfully";

                return RedirectToAction("Index");
            }

            return RedirectToAction("index");

        }

    }
}
