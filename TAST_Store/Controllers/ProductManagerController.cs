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
        [HttpPost]
        public async Task<IActionResult> Index(ProductManagerViewModel model, IFormFile image1, IFormFile image2, IFormFile image3)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var cats = await _context.Catologies.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var viewModel = new ProductManagerViewModel
            {
                Menus = menus,
                Cats = cats,
                Product = model.Product
            };
            if (ModelState.IsValid)
            {
                if (model.Product.Img1 != null)
                {
                    model.Product.Img1 = await SaveImage(image1);
                }
                if (model.Product.Img2 != null)
                {
                    model.Product.Img2 = await SaveImage(image2);
                }
                if(model.Product.Img3 != null)
                {
                    model.Product.Img3 = await SaveImage(image3);
                }
                model.Product.Img1 = "images/" + model.Product.Img1;
                model.Product.Img2 = "images/" + model.Product.Img2;
                model.Product.Img3 = "images/" + model.Product.Img3;
                _context.Products.Add(model.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "ProductManager");
            }
            return View(viewModel);
        }

        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName;
        }
    }
}
