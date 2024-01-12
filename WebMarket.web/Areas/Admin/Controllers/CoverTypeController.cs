using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebMarket.DataAccesss.Services;
using WebMarket.Models;

namespace WebMarket.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly CoverTypeService _coverTypeService;
        public CoverTypeController(CoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService;
        }
        public IActionResult Index()
        {
            IEnumerable CoverTypeList = _coverTypeService.GetAll();
            return View(CoverTypeList);
        }
        //Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _coverTypeService.Add(obj);
                _coverTypeService.Save();
                TempData["succes"] = "تایپ جدید با موفقیت ایجاد شد";
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

            var coverTypeFromDbFirst = _coverTypeService.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFromDbFirst == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDbFirst);
        }
        //Post
        [HttpPost]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _coverTypeService.Update(obj);
                _coverTypeService.Save();
                TempData["succes"] = "تایپ با موفقیت ویرایش شد";
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
            var coverTypeFromDb = _coverTypeService.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFromDb == null)
            {
                return NotFound();
            }
            return View(coverTypeFromDb);
        }
        //Post
        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            var obj = _coverTypeService.GetFirstOrDefault(u => u.Id == id);
            _coverTypeService.Remove(obj);
            _coverTypeService.Save();
            TempData["succes"] = "تایپ با موفقیت حذف شد";
            return RedirectToAction("Index");

        }
    }
}
