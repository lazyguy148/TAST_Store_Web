using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAST_Store.Models;
using TAST_Store.ViewModels;
namespace TAST_Store.Controllers
{
    public class AccountController : Controller
    {
        private readonly TAST_STOREContext _context;
        public AccountController(TAST_STOREContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accounts = await _context.Users.Where(m => m.Hide == 0).ToListAsync();
            var viewModel = new AccountViewModel
            {
                Users = accounts
            };
            return View();
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}
