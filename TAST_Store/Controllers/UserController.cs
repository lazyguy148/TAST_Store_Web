using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TAST_Store.Models;
using TAST_Store.ViewModels;

namespace TAST_Store.Controllers
{
    public class UserController : Controller
    {
        private readonly TAST_STOREContext _context;
        public UserController(TAST_STOREContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m => m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>m.Order).Take(2).ToListAsync();
            
            var viewModel = new UserViewModel
            {
                 Menus = menus,
                 Blogs = blogs,
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>m.Order).Take(2).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Blogs = blogs,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
           m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
           m.Order).Take(2).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Register = model.Register,
            };
            if (model.Register != null)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Register.Username);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập đã tồn tại.";
                    return View(viewModel);
                }
                model.Register.Password = HashWithSHA512(EncryptWithShiftCipher(model.Register.Password));
                model.Register.Permission = 0;
                model.Register.Hide = 0;
                _context.Users.Add(model.Register);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "User");
            }
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
           m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
           m.Order).Take(2).ToListAsync();
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Register = model.Register,
            };
            if (model.Register != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username ==model.Register.Username);
                if (user != null && VerifyPassword(model.Register.Password, user.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Permission.ToString()),
                    };
                    var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                    };
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);
                    if(user.Permission == 1)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                    return View(viewModel);
                }
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Info()
        {
            var menus = await _context.Menus.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).ToListAsync();
            var blogs = await _context.Blogs.Where(m => m.Hide == 0).OrderBy(m =>
            m.Order).Take(2).ToListAsync();
            var users = new User();
            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                if (username != null)
                {
                    users = await _context.Users.FirstOrDefaultAsync(m => m.Username ==
                    username);
                }
            }
            var viewModel = new UserViewModel
            {
                Menus = menus,
                Blogs = blogs,
                Register = users,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
        public async Task<IActionResult> _BlogPartial()
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

        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            string hashedInputPassword = HashWithSHA512(EncryptWithShiftCipher(inputPassword));
            return hashedInputPassword == hashedPassword;
        }
    }
}

