using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.DataAccess;
using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
namespace Website_Selling_Computer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =Role.Role_Admin)]
    public class ProductsController : Controller
    {
        private readonly IProduct _productRepository;
        private readonly IProductCategory _productCategoryRepository;
        private readonly IManufacturer _manufacturerRepository;
        private readonly IProductDetails _productDetailsRepository;

        private readonly WebsiteSellingComputerDbContext _websiteSellingComputerDbContext;
        public ProductsController(IProduct productRepository,IProductCategory productCategoryRepository,
            WebsiteSellingComputerDbContext dbContext, IManufacturer manufacturerRepo, IProductDetails productDetailsRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _manufacturerRepository = manufacturerRepo;
            _websiteSellingComputerDbContext = dbContext;
            _productDetailsRepository = productDetailsRepository;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var product = await _productRepository.GetAllAsync();
            return View(product);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName); //

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName ;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _productDetailsRepository.GetProductDetailsByIdAsync(id);

            if(productDetails == null) 
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

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile imageUrl, List<IFormFile> images)
        {

            if (ModelState.IsValid)
            {
                if(imageUrl != null)
                {
                    product.MainImage = await SaveImage(imageUrl);
                }
                if(images != null)
                {
                    product.ProductImages = new List<ProductImage>();
                    foreach(var item in images)
                    {
                        ProductImage imageCollection = new ProductImage
                        {
                            ProductID = product.ProductID,
                            ImageUrl =await SaveImage(item),
                        };
                        product.ProductImages.Add(imageCollection);
                    }
                }
                await  _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var category = await _productCategoryRepository.GetAllAsync();
                var manufacturers = await _manufacturerRepository.GetAllAsync();
                ViewBag.Manufacturers = new SelectList(manufacturers, "ManufacturerID", "ManufacturerName");
                ViewBag.Categories = new SelectList(category, "CategoryID", "Description");    
                return View(product);
            }
            
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
                    product.MainImage = existingProduct.MainImage;
                }
                else
                {
                    // Lưu hình ảnh mới
                    product.MainImage = await SaveImage(imageUrl);
                }
                existingProduct.ProductName= product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.MainImage = product.MainImage;
                existingProduct.ManufacturerID = product.ManufacturerID;

                await _productRepository.UpdateAsync(existingProduct);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _productCategoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "Description");
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
