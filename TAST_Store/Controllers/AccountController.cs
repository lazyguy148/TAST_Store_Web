﻿using Microsoft.AspNetCore.Mvc;
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
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var accounts = await _context.Users.Where(m => m.Hide == 0).OrderBy(m=>m.Order).ToListAsync();
            var viewModel = new AccountViewModel
            {
                Menus = menus,
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
