﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TAST_Store.Models;
using TAST_Store.ViewModels;

namespace TAST_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly TAST_STOREContext _context;
        public HomeController(TAST_STOREContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>m.Order).Take(2).ToListAsync();
            var slides = await _context.Sliders.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var male_prods = await _context.Products.Where(m => m.Hide == 0 && m.IdCat ==1).OrderBy(m => m.Order).Take(3).ToListAsync();
            var male_cate_prods = await _context.Catologies.Where(m => m.IdCat ==1).FirstOrDefaultAsync();
            var female_prods = await _context.Products.Where(m => m.Hide == 0 && m.IdCat ==2).OrderBy(m => m.Order).Take(3).ToListAsync();
            var female_cate_prods = await _context.Catologies.Where(m => m.IdCat ==2).FirstOrDefaultAsync();
            var male_pant_prods = await _context.Products.Where(m => m.Hide == 0 && m.IdCat ==3).OrderBy(m => m.Order).Take(3).ToListAsync();
            var male_pant_cate_prods = await _context.Catologies.Where(m => m.IdCat ==3).FirstOrDefaultAsync();
            var female_pant_prods = await _context.Products.Where(m => m.Hide == 0 && m.IdCat == 4).OrderBy(m => m.Order).Take(3).ToListAsync();
            var female_pant_cate_prods = await _context.Catologies.Where(m => m.IdCat ==4).FirstOrDefaultAsync();
            var viewModel = new HomeViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Sliders = slides,
                MaleProds = male_prods,
                FemaleProds = female_prods,
                MaleCateProds = male_cate_prods,
                FemaleCateProds = female_cate_prods,
                MalePantProds = male_pant_prods,
                FemalePantProds = female_pant_prods,
                MalePantCateProds = male_pant_cate_prods,
                FemalePantCateProds = female_pant_cate_prods,
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
        public async Task<IActionResult> _SlidePartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> _ProductPartial()
        {
            return PartialView();
        }
    }
}
