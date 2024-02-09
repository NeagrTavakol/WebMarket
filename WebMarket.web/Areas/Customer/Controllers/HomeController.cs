using Microsoft.AspNetCore.Mvc;
using WebMarket.DataAccesss.Services.Interface;
using WebMarket.Model.ViewModels;

namespace WebMarket.web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            ShoppingCartVM shoppingCart = new ShoppingCartVM
            {
                Product = _productService.GetFirstOrDefault(x => x.Id == id),
                Count = 1
            };
            return View(shoppingCart);
        }
    }
}
