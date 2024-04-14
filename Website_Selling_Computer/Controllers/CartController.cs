using Website_Selling_Computer.Models;
using Website_Selling_Computer.Repositories.Interfaces;
using Website_Selling_Computer.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Website_Selling_Computer.Session;
using Microsoft.EntityFrameworkCore;
using Website_Selling_Computer.Extensions;
using Website_Selling_Computer.Repositories.EntityFrameworks;
using System.Diagnostics;
using Website_Selling_Computer.ViewModel;
using MimeKit;
using MailKit.Net.Smtp;
using System.Net;
using System.Net.Mail;

namespace Website_Selling_Computer.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly WebsiteSellingComputerDbContext _context;
        private readonly IProduct _productRepo;
        private readonly IOrder _orderRepo;
        private readonly IPayingMethod _methodRepo;
        private readonly UserManager<User> _userManager;
        public CartController(WebsiteSellingComputerDbContext context,
           IProduct productRepo, UserManager<User> userManager, IOrder orderRepo, IPayingMethod methodRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _userManager = userManager;
            _orderRepo = orderRepo;
            _methodRepo = methodRepo;
        }
        public IActionResult NotFound(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            return View();
        }
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index");
            }
            var paymentMethod = await _methodRepo.GetAllAsync();
            ViewData["PaymentMethods"] = paymentMethod;
            var viewModel = new CartViewModel
            {
                Cart = cart,
                Order = new Order()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            try
            {
                var cart =
           HttpContext.Session.GetObjectFromJson<Cart>("Cart");
                if (cart == null || !cart.Items.Any())
                {
                    // Xử lý giỏ hàng trống...
                    return RedirectToAction("Index");
                }
                var user = await _userManager.GetUserAsync(User);
                order.UserID = user.Id;
                order.OrderDate = DateTime.UtcNow;
                order.TotalAmount = cart.Items.Sum(i => i.Price * i.Quantity);
                order.OrderDetails = cart.Items.Select(i => new OrderDetail
                {
                    ProductID = i.ProductID,
                    Quantity = i.Quantity,
                    Price = i.Price * i.Quantity
                }).ToList();
                foreach (var item in order.OrderDetails)
                {
                    var productInventoryQuantity = await _context.Inventory.FirstOrDefaultAsync(i => i.ProductID == item.ProductID);
                    if (productInventoryQuantity != null)
                    {
                        productInventoryQuantity.QuantityInStock -= item.Quantity;
                        _context.Inventory.Update(productInventoryQuantity);
                    }
                }
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                if (order.PaymentMethodId == 2)
                {
                    string message = "Confirm Checkout"; 
                     string Text = $"Thank you for your order, {user.UserName}! Your order will be delivered to {order.ShippingAddress}";

                    var client = new System.Net.Mail.SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("5c2154443e6717", "1612ca29a44c6e"),
                        EnableSsl = true
                    };
                    client.Send("STMShop@example.com", user.Email, message, Text);
                    System.Console.WriteLine("Sent");
                }
                if (order.PaymentMethodId == 1)
                {
                    /*using (var httpClient = new HttpClient())
                    {
                        var content = new FormUrlEncodedContent(new[]
                        {
                    new KeyValuePair<string, string>("clientTransactionRef", "your_unique_transaction_ref"),
                    new KeyValuePair<string, string>("currency", "NGN"),
                    new KeyValuePair<string, string>("amount", order.TotalAmount.ToString()),
                });

                        var response = await httpClient.PostAsync("http://localhost:5000/api/transfer", content);

                        if (!response.IsSuccessStatusCode)
                        {
                            // Xử lý lỗi
                            return View("TransferFailed");
                        }
                    }*/
                }
                HttpContext.Session.Remove("Cart");
                await HttpContext.Session.CommitAsync();
                return View("OrderCompleted", order.OrderID); // Trang xác nhận hoàn thành đơn hàng
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier});
            } 
        }


        public IActionResult OrderCompleted()
        {
            return View();
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            var cartDetails = _context.CartDetails.Include(cd => cd.Product).ToList();
            ViewBag.CartDetails= cartDetails;
            return View(cart);
        }
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var product = await _productRepo.GetByIdAsync(productId);

            if (product != null)
            {
                var cartDetail = new CartDetail
                {
                    ProductName = product.ProductName!=null?product.ProductName:"",
                    ProductID = productId,
                    Quantity = quantity,
                    ProductCategoryDescription = product.ProductCategory.Description,
                    Price = product.Price
                };
                var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();

                cart.AddItem(cartDetail);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                return RedirectToAction("Index");
            }
            else
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }
        }
        public IActionResult RemoveFromCart(int productId)
        {
            var cart =
           HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart is not null)
            {
                cart.RemoveItem(productId);
                // Lưu lại giỏ hàng vào Session sau khi đã xóa mục
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Increase(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            cart.IncreaseQuantity(productId);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Decrease(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            cart.DecreaseQuantity(productId);
            HttpContext.Session.SetObjectAsJson("Cart", cart);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        [Authorize(Roles = Role.Role_Customer)]
        public async Task<IActionResult> ViewingOrderHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                return Forbid();  
            }
            var orders = await _context.Orders.Include(i=>i.OrderDetails).Where(o=>o.UserID == user.Id).ToListAsync();
            return View(orders);
        }
    }
}
