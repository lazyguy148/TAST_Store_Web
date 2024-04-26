using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using TAST_Store.Models;
using TAST_Store.ViewModels;
namespace TAST_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly TAST_STOREContext _context;
        public ProductController(TAST_STOREContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 6)
        {
            var totalCount = _context.Products.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var data = _context.Products
                .OrderBy(d => d.IdPro)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).Take(2).ToListAsync();
            var prods = await _context.Products.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var viewModel = new ProductViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Prods = data,
                PageSize = pageSize,
                TotalPages = totalPages,
                Page = page
            };
            return View(viewModel);
        }

        public async Task<IActionResult> CateProd(string slug, long id)
        {
            
            
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).Take(2).ToListAsync();
            var cateProds = await _context.Catologies
            .Where(cp => cp.IdCat == id && cp.Link == slug).FirstOrDefaultAsync();
            if (cateProds == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "CateProd Error",
                };
                return View("Error", errorViewModel);
            }
            var prods = await _context.Products.Where(m => m.Hide == 0 && m.IdCat == cateProds.IdCat).OrderBy(m => m.Order).ToListAsync();
            
            var viewModel = new ProductViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Prods = prods,
                cateName = cateProds.NameCat,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ProdDetail(string slug, long id)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>m.Order).Take(2).ToListAsync();
            var prods = await _context.Products.Where(m => m.Link == slug && m.IdPro ==id).ToListAsync();
            if (prods == null)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = "Product Error",
                };
                return View("Error", errorViewModel);
            }
            var viewModel = new ProductViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Prods = prods,
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

