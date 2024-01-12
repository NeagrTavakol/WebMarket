using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebMarket.DataAccesss.Services.Interface;
using WebMarket.Models;

namespace WebMarket.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            IEnumerable CategoryList = _categoryService.GetAll();
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
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "مقدار ترتیب نمایش نباید با مقدار نام برابر باشد");
            }
            if (ModelState.IsValid)
            {
                _categoryService.Add(obj);
                _categoryService.Save();
                TempData["succes"] = "دسته جدید با موفقیت ایجاد شد";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.categories.Find(id);
            var CategoryFromDbFirst = _categoryService.GetFirstOrDefault(u => u.Id == id);
            if (CategoryFromDbFirst == null)
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
                _categoryService.Update(obj);
                _categoryService.Save();
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
            var categoryFromDb = _categoryService.GetFirstOrDefault(u => u.Id == id);
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
            var obj = _categoryService.GetFirstOrDefault(u => u.Id == id);
            _categoryService.Remove(obj);
            _categoryService.Save();
            TempData["succes"] = "دسته با موفقیت حذف شد";
            return RedirectToAction("Index");

        }
    }
}
