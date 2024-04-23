using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAST_Store.Models;
using TAST_Store.ViewModels;

namespace TAST_Store.Controllers
{
    public class BlogManagerController : Controller
    {
        private readonly TAST_STOREContext _context;
        public BlogManagerController(TAST_STOREContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var accounts = await _context.Users.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new BlogManagerViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Users = accounts,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}

