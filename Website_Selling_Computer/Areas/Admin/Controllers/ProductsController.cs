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
        private readonly IOrder _orderRepo;
        private readonly I_Inventory _inventoryRepository;
        private readonly ICart _cartRepository;
        private readonly IManufacturer _manufacturerRepository;
        public ProductsController(IProduct productRepository,IProductCategory productCategoryRepository,
            ICart cartRepo, IOrder orderRepo, I_Inventory inventoryRepo, IManufacturer manufacturerRepo)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _orderRepo = orderRepo;
            _inventoryRepository = inventoryRepo;
            _manufacturerRepository = manufacturerRepo;
            _cartRepository = cartRepo;
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
            return "/images/" + image.FileName;
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                return NoContent();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _productCategoryRepository.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile imageUrl, List<IFormFile> images)
        {
            if (ModelState.IsValid)
            {
               /* if(imageUrl != null)
                {
                    product.MainImageID = await SaveImage(imageUrl);
                }
                if(images != null)
                {
                    product.ProductImage = new List<ProductImage>();
                    foreach(var item in images)
                    {
                        ProductImage image = new ProductImage
                        {
                            ProductID = product.ProductID,
                            ImageUrl =await SaveImage(item),
                        };
                        product.ProductImage.Add(image);
                    }
                }*/
                await  _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var category = await _productCategoryRepository.GetAllAsync();
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
            ViewBag.Categories = new SelectList(category, "CategoryID", "Description");
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile imageUrl)
        {
            ModelState.Remove("ImageUrl");

            if (id != product.ProductID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingProduct = await _productRepository.GetByIdAsync(id);

               /* if (imageUrl == null)
                {
                    product.MainImageID = existingProduct.MainImageID;
                }
                else
                {
                    // Lưu hình ảnh mới
                    product.MainImageID = await SaveImage(imageUrl);
                }*/
                existingProduct.ProductName= product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.CategoryID = product.CategoryID;
            /*    existingProduct.MainImageID = product.MainImageID;*/
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
