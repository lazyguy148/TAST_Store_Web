using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAST_Store.Models;
using TAST_Store.ViewModels;

namespace TAST_Store.Controllers
{
    public class BlogController : Controller
    {
        private readonly TAST_STOREContext _context;
        public BlogController(TAST_STOREContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>m.Order).Take(2).ToListAsync();
            var viewModel = new BlogViewModel
            {
                Menus = menus,
                Blogs = blogs,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> BlogDetail(string slug, long id)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            if (blogs == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Blog Error",
                };
                return View("Error", errorViewModel);
            }
            var viewModel = new BlogViewModel
            {
                Menus = menus,
                Blogs = blogs,
            };
            return View(viewModel);
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _BlogPartial()
        {
            return PartialView();
        }
    }
}

