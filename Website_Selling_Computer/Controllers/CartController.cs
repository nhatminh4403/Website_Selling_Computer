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
using Website_Selling_Computer.PaymentMethods.VNPay.Services;

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
        private readonly IVnPayService _vnPayService;
        public CartController(WebsiteSellingComputerDbContext context,
           IProduct productRepo, UserManager<User> userManager, IOrder orderRepo, IPayingMethod methodRepo, IVnPayService vnPayService)
        {
            _context = context;
            _productRepo = productRepo;
            _userManager = userManager;
            _orderRepo = orderRepo;
            _methodRepo = methodRepo;
            _vnPayService = vnPayService;
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
        public async Task<IActionResult> Checkout(CartViewModel cartViewModel)
        {
            try
            {
                var cart =
           HttpContext.Session.GetObjectFromJson<Cart>("Cart");

                HttpContext.Session.SetObjectAsJson("viewModel", cartViewModel);
                if (cart == null || !cart.Items.Any())
                {
                    // Xử lý giỏ hàng trống...
                    return RedirectToAction("Index");
                }
                var user = await _userManager.GetUserAsync(User);

                if (cartViewModel.PaymentMethod.ToLower() == "chuyển khoản")
                {
                    HttpContext.Session.SetObjectAsJson("Cart", cart);
                    return RedirectToAction("ProcessVNPayPayment");


                }
                else
                {
                    cartViewModel.Order.PaymentMethodId = 2;
                    cartViewModel.Order.UserID = user.Id;
                    cartViewModel.Order.ShippingAddress = user.Address;
                    cartViewModel.Order.TotalAmount = cart.Items.Sum(i => i.Price * i.Quantity);
                    cartViewModel.Order.OrderDate = DateTime.UtcNow;
                    cartViewModel.Order.OrderDetails = cart.Items.Select(i => new OrderDetail
                    {
                        ProductID = i.ProductID,
                        Quantity = i.Quantity,
                        Price = i.Price * i.Quantity
                    }).ToList();
                    foreach (var item in cartViewModel.Order.OrderDetails)
                    {
                        var productInventoryQuantity = await _context.Inventory.FirstOrDefaultAsync(i => i.ProductID == item.ProductID);
                        if (productInventoryQuantity != null)
                        {
                            productInventoryQuantity.QuantityInStock -= item.Quantity;
                            _context.Inventory.Update(productInventoryQuantity);
                        }
                    }

                    _context.Orders.Add(cartViewModel.Order);
                    await _context.SaveChangesAsync();
                    HttpContext.Session.Remove("Cart");
                    await HttpContext.Session.CommitAsync();
                    return View("OrderCompleted", cartViewModel.Order.OrderID);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id
                ?? HttpContext.TraceIdentifier
                });
            }
        }

        public async Task<IActionResult> ProcessVNPayPayment()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart == null || !cart.Items.Any())
            {
                // Xử lý giỏ hàng trống...
                return RedirectToAction("Index");
            }

            var checkoutData = HttpContext.Session.GetObjectFromJson<CartViewModel>("viewModel");
            var user = await _userManager.GetUserAsync(User);

            double totalAmount = (double)cart.Items.Sum(i => i.Price * i.Quantity);

            if (user == null)
            {
                return NotFound();
            }

            var vnPayModel = new PaymentMethods.VNPay.VnPaymentRequestModel
            {
                Price = totalAmount,
                CreatedDate = DateTime.Now,
                Description = $"Thanh toán hóa đơn {totalAmount} cho {user.FirstName + user.LastName}",
                FullName = user.FirstName + user.LastName,
                OrderId = new Random().Next(1000, 10000)
            };


            var paymentUrl = _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel);
            HttpContext.Session.SetObjectAsJson("Cart", cart);


            HttpContext.Session.SetObjectAsJson("PendingOrderData", checkoutData);

            return Redirect(paymentUrl);
        }
        [Authorize]
        public async Task<IActionResult> PaymentCallBack()
        {
            // Thực hiện thanh toán và lấy phản hồi từ VNPay
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response == null || response.VnPayResponseCode != "00")
            {
                TempData["Message"] = $"Lỗi thanh toán VNPay: {response.VnPayResponseCode}";
                return RedirectToAction("PaymentFail");
            }

            // Lấy lại thông tin từ Session
            try
            {
                var pendingOrder = HttpContext.Session.GetObjectFromJson<CartViewModel>("PendingOrderData");
                if (pendingOrder == null)
                {
                    TempData["Message"] = "Không tìm thấy thông tin đơn hàng.";
                    return RedirectToAction("PaymentFail");
                }
                var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
                if (cart == null || !cart.Items.Any())
                {
                    // Xử lý giỏ hàng trống...
                    return RedirectToAction("Index");
                }
                // Lưu đơn hàng vào cơ sở dữ liệucartViewModel.Order.TotalAmount = cart.Items.Sum(i => i.Price * i.Quantity);

                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        var user = await _userManager.GetUserAsync(User);
                        if (user == null)
                        {
                            return NotFound();
                        }
                        if (pendingOrder.Order.ShippingAddress == null)
                        {
                            pendingOrder.Order.ShippingAddress = user.Address;
                        }
                        var order = new Order
                        {
                            UserID = user.Id,
                            ShippingAddress = pendingOrder.Order.ShippingAddress,
                            TotalAmount = cart.Items.Sum(i => i.Price * i.Quantity),
                            OrderDate = DateTime.UtcNow,
                            PaymentMethodId = 1, // Cập nhật phương thức thanh toán
                            OrderDetails = cart.Items.Select(i => new OrderDetail
                            {
                                ProductID = i.ProductID,
                                Quantity = i.Quantity,
                                Price = i.Price * i.Quantity
                            }).ToList()
                        };
                        await _context.Orders.AddAsync(order);


                        foreach (var item in order.OrderDetails)
                        {
                            var productInventoryQuantity = await _context.Inventory.FirstOrDefaultAsync(i => i.ProductID == item.ProductID);
                            if (productInventoryQuantity != null)
                            {
                                productInventoryQuantity.QuantityInStock -= item.Quantity;
                                _context.Inventory.Update(productInventoryQuantity);
                            }
                        }



                        await _context.SaveChangesAsync();
                        // Xóa giỏ hàng sau khi thanh toán thành công
                        HttpContext.Session.Remove("PendingOrderData");
                        HttpContext.Session.Remove("Cart");

                        await HttpContext.Session.CommitAsync();
                        await transaction.CommitAsync();
                        // Chuyển hướng đến trang thành công
                        return RedirectToAction("OrderCompleted", order.OrderID);
                    }
                    catch (Exception ex)
                    {

                        if (transaction != null)
                        {
                            await transaction.RollbackAsync();
                        }
                        TempData["Message"] = $"Có lỗi xảy ra trong quá trình xử lý giao dịch. Vui lòng liên hệ hỗ trợ."; return RedirectToAction("PaymentFail");
                    }
                }


            }
            catch (Exception ex)
            {
                TempData["Message"] = "Có lỗi xảy ra trong quá trình xử lý giao dịch.";
                return RedirectToAction("PaymentFail");
            }
        }

        public IActionResult PaymentFail()
        {
            return View();
        }
        public IActionResult OrderCompleted()
        {
            return View();
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
            var cartDetails = _context.CartDetails.Include(cd => cd.Product).ToList();
            ViewBag.CartDetails = cartDetails;
            return View(cart);
        }
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var product = await _productRepo.GetByIdAsync(productId);

            if (product != null)
            {
                var cartDetail = new CartDetail
                {
                    ProductName = product.ProductName != null ? product.ProductName : "",
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
            if (user == null)
            {
                return Forbid();
            }
            var orders = await _context.Orders.Include(i => i.OrderDetails).Include(i => i.PaymentMethod).Where(o => o.UserID == user.Id).ToListAsync();
            return View(orders);
        }
    }
}
