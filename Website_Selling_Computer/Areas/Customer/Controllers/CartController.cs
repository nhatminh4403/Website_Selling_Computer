using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
using Website_Selling_Computer.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Website_Selling_Computer.Session;

namespace Website_Selling_Computer.Areas.Customer.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly WebsiteSellingComputerDbContext _context;
        private readonly ICart _cartRepo;
        private readonly IProduct _productRepo;
        private readonly IProductCategory _productCategoryRepo;
        private readonly IManufacturer _manufacturerRepo;
        private readonly UserManager<IdentityUser> _userManager;
        public CartController(WebsiteSellingComputerDbContext context, ICart cartRepo, IProduct productRepo, IProductCategory productCategoryRepo, IManufacturer manufacturerRepo, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _cartRepo = cartRepo;
            _productRepo = productRepo;
            _productCategoryRepo = productCategoryRepo;
            _manufacturerRepo = manufacturerRepo;
            _userManager = userManager;
        }
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
       /* public async Task<IActionResult> Checkout(Order order)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if(cart == null || !cart.items)
            {

            }
        }*/
        public IActionResult Index()
        {
            return View();
        }
    }
}
