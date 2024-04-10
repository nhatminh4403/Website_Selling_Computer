using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Website_Selling_Computer.Models;

namespace Website_Selling_Computer.Areas.Admin.Controllers
{
    [Authorize(Roles = Role.Role_Admin)]
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly UserManager<User> _userManager;
        public CustomerController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            IList<User> customer = _userManager.GetUsersInRoleAsync("Customer").Result;
            return View(customer);
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customer = await _userManager.FindByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            // Delete the customer
            var result = await _userManager.DeleteAsync(customer);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(customer);
        }
    }
}
