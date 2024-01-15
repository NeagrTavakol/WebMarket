using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using WebMarket.DataAccesss.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICoverTypeService _coverTypeService;
        public ProductController(IProductService productService, ICategoryService categoryService, ICoverTypeService coverTypeService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _coverTypeService = coverTypeService;
        }
        public IActionResult Index()
        {
            IEnumerable ProductList = _productService.GetAll();
            return View(ProductList);
        }
        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(Product obj)
        {

            if (ModelState.IsValid)
            {
                _productService.Add(obj);
                _productService.Save();
                TempData["succes"] = "محصول جدید با موفقیت ایجاد شد";
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
            var ProductFromDbFirst = _productService.GetFirstOrDefault(u => u.Id == id);
            if (ProductFromDbFirst == null)
            {
                return NotFound();
            }
            return View(ProductFromDbFirst);
        }
        //Post
        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _productService.Update(obj);
                _productService.Save();
                TempData["succes"] = "محصول با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //Get
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                Product = new(),
                CategoryList = _categoryService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CoverTypeList = _coverTypeService.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            if (id == null || id == 0)
            {
                //create
                /*ViewBag.CategoryList = CategoryList;
                ViewData["CoverTypeList"] = CoverTypeList;*/
                return View(productVM);
            }
            else
            {
                //Update
            }
            return View();
        }
        //Get
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _productService.GetFirstOrDefault(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _productService.GetFirstOrDefault(u => u.Id == id);
            _productService.Remove(obj);
            _productService.Save();
            TempData["succes"] = "محصول با موفقیت حذف شد";
            return RedirectToAction("Index");

        }
    }
}
