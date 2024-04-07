using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
namespace Website_Selling_Computer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct _productRepo;
        private readonly IProductCategory _productCategoryRepo;
        private readonly IProductDetails _productDetailsRepo;
        public HomeController(ILogger<HomeController> logger, IProduct productRepo,IProductCategory productCategory,IProductDetails productDetails)
        {
            _logger = logger;
            _productRepo = productRepo;
            _productCategoryRepo = productCategory;
            _productDetailsRepo = productDetails;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepo.GetAllAsync();    
            return View(products);
        }

        public async Task<IActionResult> GetCategoriesView()
        {
            var categories = await _productCategoryRepo.GetAllAsync();
            return View(categories);
        }
        public async Task<IActionResult> ProductsDetailView(int id)
        {
            var productsDetail = await _productDetailsRepo.GetProductDetailsByIdAsync(id);
            return View(productsDetail);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
