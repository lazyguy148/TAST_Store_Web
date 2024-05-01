using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAST_Store.Models;
using TAST_Store.ViewModels;

namespace TAST_Store.Controllers
{
    public class ProductManagerController : Controller
    {
        private readonly TAST_STOREContext _context;
        public ProductManagerController(TAST_STOREContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var cats = await _context.Catologies.Where(m=>m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new ProductManagerViewModel
            {
                Menus = menus,
                Cats = cats
            };
            return View(viewModel);
        }

        
    }
}
