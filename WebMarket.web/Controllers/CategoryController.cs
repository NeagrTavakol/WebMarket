using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebMarket.web.Data;
using WebMarket.web.Models;

namespace WebMarket.web.Controllers
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
            IEnumerable CategoryList = _db.categories;
            return View(CategoryList);
        }
        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار ترتیب نمایش نباید با مقدار نام برابر باشد");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["succes"] = "دسته جدید با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار ترتیب نمایش نباید با مقدار نام برابر باشد");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["succes"] = "دسته با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.categories.Find(id);
            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["succes"] = "دسته با موفقیت حذف شد";
            return RedirectToAction("Index");

        }
    }
}
