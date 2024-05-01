using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
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
        [HttpGet]
        public async Task<IActionResult> AddAccount()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var permissions = await _context.Permissions.ToListAsync();
            var viewModel = new AccountViewModel
            {
                Menus = menus,
                Permissions = permissions,
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccount(AccountViewModel model)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var permissions = await _context.Permissions.ToListAsync();
            var viewModel = new AccountViewModel
            {
                Menus = menus,
                Permissions = permissions,
                Acc = model.Acc
            };
            if(model.Acc != null)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Acc.Username);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                    return View(viewModel);
                }
                model.Acc.Password = HashWithSHA512(EncryptWithShiftCipher(model.Acc.Password));
                model.Acc.Hide = 0;
                _context.Users.Add(model.Acc);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Account");
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var Accounts = await _context.Users.ToListAsync();
            foreach (var acc in Accounts)
            {
                if(userId == acc.IdUsers)
                {
                    _context.Users.Remove(acc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Account");
                }
            }
            return Ok("User deleted successfully");
        }



        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }

        private string EncryptWithShiftCipher(string plainText)
        {

            int shift = 3;
            StringBuilder cipherText = new StringBuilder();

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    char encryptedChar = (char)(c + shift);
                    if ((char.IsLower(c) && encryptedChar > 'z') || (char.IsUpper(c) && encryptedChar > 'Z'))
                    {
                        encryptedChar = (char)(c - (26 - shift));
                    }
                    cipherText.Append(encryptedChar);
                }
                else
                {
                    cipherText.Append(c);
                }
            }

            return cipherText.ToString();
        }

        private string HashWithSHA512(string input)
        {
            using (SHA512 sha = SHA512.Create())
            {
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("X2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
