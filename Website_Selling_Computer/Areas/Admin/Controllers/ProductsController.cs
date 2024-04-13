using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
namespace Website_Selling_Computer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Role_Admin)]
    public class ProductsController : Controller
    {
        private readonly IProduct _productRepository;
        private readonly IProductCategory _productCategoryRepository;
        private readonly IManufacturer _manufacturerRepository;
        private readonly I_Inventory _inventoryRepository;
        private readonly IProductDetails _productDetailsRepository;

        private readonly WebsiteSellingComputerDbContext _websiteSellingComputerDbContext;
        public ProductsController(IProduct productRepository, IProductCategory productCategoryRepository,
            WebsiteSellingComputerDbContext dbContext, IManufacturer manufacturerRepo, IProductDetails productDetailsRepository, I_Inventory inventoryRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _manufacturerRepository = manufacturerRepo;
            _websiteSellingComputerDbContext = dbContext;
            _productDetailsRepository = productDetailsRepository;
            _inventoryRepository = inventoryRepository;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAllAsync();
            foreach(var product in products)
            {
                if(product.Manufacturer != null)
                {
                    var manuImage = product.Manufacturer.ManufacturerImage;
                }
            }
            return View(products);
        }

        private async Task<string?> SaveImage(IFormFile image)
        {
            
            var savePath = Path.Combine("wwwroot/images", image.FileName); //

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _productDetailsRepository.GetProductDetailsByIdAsync(id);
            
            if (productDetails == null)
            {
                return NoContent();
            }

            return View(productDetails);
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _productCategoryRepository.GetAllAsync();
            var manufacturers = await _manufacturerRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "Description");
            ViewBag.Manufacturers = new SelectList(manufacturers, "ManufacturerID", "ManufacturerName");
            return View();
        }

        private bool IsValidData(Product product)
        {
            if (product.ProductName == null || product.ProductName.Length > 100)
            {
                return false;
            }
            if (product.Description != null && product.Description.Length > 500)
            {
                return false;
            }
            if (product.Price == null)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile MainImageUrl, List<IFormFile> ProductImages)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null");
            }
            if (/*IsValidData(product)*/ModelState.IsValid)
            {
                
                if (MainImageUrl !=null)
                {
                    product.MainImageUrl = await SaveImage(MainImageUrl);          
                }
                if (ProductImages != null)
                {
                    product.ProductImages = new List<ProductImage>();
                    foreach (var item in ProductImages)
                    {
                        ProductImage imageCollection = new ProductImage
                        {
                            ProductID = product.ProductID,
                            ImageUrl = await SaveImage(item)
                        };
                        product.ProductImages.Add(imageCollection);
                    }
                }
                await _productRepository.AddAsync(product);
             //   int productId = await _productRepository.AddAsync(product);
                await _productDetailsRepository.AddAsync(new ProductDetail
                {
                    ProductID = product.ProductID,
                    BatteryLife = "",
                    CPU = "",
                    Display = "",
                    GraphicsCard = "",
                    OperatingSystem = "",
                    RAM = "",
                    Storage = "",
                    Warranty = "",
                    Weight = ""
                });

                await _inventoryRepository.AddAsync(new Inventory
                {
                    ProductID = product.ProductID,
                    QuantityInStock = 0,
                    ReorderLevel = 20
                });

                return RedirectToAction(nameof(Index));
            }
            else
            {
                var categories = await _productCategoryRepository.GetAllAsync();
                var manufacturers = await _manufacturerRepository.GetAllAsync();
                ViewBag.Manufacturers = new SelectList(manufacturers, "ManufacturerID", "ManufacturerName");
                ViewBag.Categories = new SelectList(categories, "CategoryID", "Description");
                return View(product);
            }
        }

        public async Task<IActionResult> SearchByName(string name)
        {
            var list= await _productRepository.FindByNameAsync(name);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return RedirectToAction("Index", list);
        }

        public async Task<IActionResult> SearchByCategory(int id)
        {
            var list = await _productRepository.FindByCategoryAsync(id);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return RedirectToAction("Index", list);
        }
        public async Task<IActionResult> SearchByManufacturer(int id)
        {
            var list = await _productRepository.FindByManufacturerAsync(id);
            if (list.IsNullOrEmpty())
            {
                return NotFound();
            }
            return RedirectToAction("Index", list);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var category = await _productCategoryRepository.GetAllAsync();
            var manufacturers = await _manufacturerRepository.GetAllAsync();
            ViewBag.Manufacturers = new SelectList(manufacturers, "ManufacturerID", "ManufacturerName");
            ViewBag.Categories = new SelectList(category, "CategoryID", "Description");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile imageUrl)
        {
            ModelState.Remove("MainImage");

            if (id != product.ProductID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingProduct = await _productRepository.GetByIdAsync(id);

                if (imageUrl == null)
                {
                    product.MainImageUrl = existingProduct.MainImageUrl;
                }
                else
                {
                    // Lưu hình ảnh mới
                    product.MainImageUrl = await SaveImage(imageUrl);
                }
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.MainImageUrl = product.MainImageUrl;
                existingProduct.ManufacturerID = product.ManufacturerID;

                await _productRepository.UpdateAsync(existingProduct);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _productCategoryRepository.GetAllAsync();
            var manufacturers = await _manufacturerRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "Description");
            ViewBag.Manufacturers = new SelectList(manufacturers, "ManufacturerID", "ManufacturerName");

            return View(product);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
