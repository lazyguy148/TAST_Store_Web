using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAST_Store.Models;
using TAST_Store.ViewModels;

namespace TAST_Store.Controllers
{
    public class AdminController : Controller
    {
        private readonly TAST_STOREContext _context;
        public AdminController(TAST_STOREContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(UserViewModel model)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                if (user != null && user.Permission != 1)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}
