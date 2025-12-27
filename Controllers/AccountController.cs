using Mahara.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mahara.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ===== Register =====
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string fullName, string city)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("Email", "البريد الإلكتروني مطلوب");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("Password", "كلمة المرور مطلوبة");
            }
            if (string.IsNullOrWhiteSpace(fullName))
            {
                ModelState.AddModelError("FullName", "الاسم الكامل مطلوب");
            }
            if (string.IsNullOrWhiteSpace(city))
            {
                ModelState.AddModelError("City", "المدينة مطلوبة");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FullName = fullName,
                City = city,
                Track = "General"
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            // Add Identity errors to ModelState to display on the view
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        // ===== Login =====
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "البريد الإلكتروني وكلمة المرور مطلوبان");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "البريد الإلكتروني أو كلمة المرور غير صحيحة");
            return View();
        }

        // ===== Logout =====
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
