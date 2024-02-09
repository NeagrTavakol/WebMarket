using DocumentFormat.OpenXml.Presentation;
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
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(IProductService productService,
            ICategoryService categoryService,
            ICoverTypeService coverTypeService,
            IWebHostEnvironment hostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _coverTypeService = coverTypeService;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            /*IEnumerable ProductList = _productService.GetAll();*/
            /*return View(ProductList);*/
            return View();
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
                productVM.Product = _productService.GetFirstOrDefault(u => u.Id == id);
                return View(productVM);     
            }

            return View(productVM);
        }

        //Post
        [HttpPost]
        public IActionResult Upsert(ProductVM obj,IFormFile? file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");
                    var extenstion = Path.GetExtension(file.FileName);
                    if(obj.Product.ImgeUrl !=null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath,obj.Product.ImgeUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using(var filestrems=new FileStream(Path.Combine(uploads,fileName+extenstion),FileMode.Create))
                    {
                        file.CopyTo(filestrems);
                    }
                    obj.Product.ImgeUrl = fileName + extenstion;
            }
                if(obj.Product.Id==0) _productService.Add(obj);
                else _productService.Update(obj.Product);
                _productService.Save();
                TempData["succes"] = "محصول با موفقیت ویرایش شد";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        #region API CALL    
        [HttpGet]
        public IActionResult GetAll() 
        {
            var productList =_productService.GetAll();
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _productService.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "خطا در حذف " });
            }
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImgeUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _productService.Remove(obj);
            return Json(new { success = true, message = "حذف موفقیت آمیز بود" });
        }
        #endregion
    }
}
