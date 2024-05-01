using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAST_Store.Models;
using TAST_Store.ViewModels;

namespace TAST_Store.Controllers
{
    public class CatManagerController : Controller
    {
        private readonly TAST_STOREContext _context;
        public CatManagerController(TAST_STOREContext context)
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
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new CatManagerViewModel
            {
                Menus = menus,
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CatManagerViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new CatManagerViewModel
            {
                Menus = menus,
                Cat = model.Cat
            };
            if(model.Cat != null)
            {
                var existingCat = await _context.Catologies.FirstOrDefaultAsync(u => u.NameCat == model.Cat.NameCat);
                if (existingCat != null)
                {
                    ViewBag.ErrorMessage = "Đã có loại hàng này!";
                    return View(viewModel);
                }
                model.Cat.Hide = 0;
                model.Cat.Order = (_context.Catologies.OrderBy(m => m.Order).Count() +1);
                _context.Catologies.Add(model.Cat);
                await _context.SaveChangesAsync();
                return View(viewModel);
            }
            return View(viewModel);
        }
    }
}
