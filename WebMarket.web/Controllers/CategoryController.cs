using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebMarket.DataAccess;
using WebMarket.DataAccesss.Repository.IRepository;
using WebMarket.Models;

namespace WebMarket.web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;
        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable CategoryList = _db.Category.GetAll();
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
                _db.Category.Add(obj);
                _db.Save();
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
            //var categoryFromDb = _db.categories.Find(id);
            var CategoryFromDbFirst = _db.Category.GetFirstOrDefault(u => u.Id == id);
            if(CategoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(CategoryFromDbFirst);
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
                _db.Category.Update(obj);
                _db.Save();
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
            var categoryFromDb = _db.Category.GetFirstOrDefault(u => u.Id==id);
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
            var obj = _db.Category.GetFirstOrDefault(u => u.Id == id);
            _db.Category.Remove(obj);
            _db.Save();
            TempData["succes"] = "دسته با موفقیت حذف شد";
            return RedirectToAction("Index");

        }
    }
}
