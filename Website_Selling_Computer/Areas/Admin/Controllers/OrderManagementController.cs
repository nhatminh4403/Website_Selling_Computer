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
    [Authorize (Roles = Role.Role_Admin)]
    public class OrderManagementController : Controller
    {
        private readonly IOrder _orderRepo;
        private readonly IOrderDetails _orderDetailsRepo;
        private readonly WebsiteSellingComputerDbContext _websiteSellingComputerDbContext;
        public OrderManagementController(IOrder orderRepo, IOrderDetails orderDetailsRepo, WebsiteSellingComputerDbContext websiteSellingComputerDbContext)
        {
            _orderRepo = orderRepo;
            _orderDetailsRepo = orderDetailsRepo;
            _websiteSellingComputerDbContext = websiteSellingComputerDbContext;
        }

        public async Task<IActionResult> Index()   
        {
            var orderList = await _orderRepo.GetAllAsync();
            return View(orderList);
        }
        public async Task<IActionResult> Details(int id)
        {
            var ordersDetailsList = await _orderDetailsRepo.GetOrderDetailsByIdAsync(id);
            if (ordersDetailsList != null)
            {
                return View(ordersDetailsList);
            }
            else 
                return NoContent();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderRepo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
