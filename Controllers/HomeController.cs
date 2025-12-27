using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mahara.Models;
using Mahara.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Mahara.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        // Inject the database context, UserManager, and SignInManager
        public HomeController(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ===== LOGIN PAGE =====
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login using Identity
        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index"); // Logged in successfully
                }
            }

            ViewBag.Error = "البريد الإلكتروني أو كلمة المرور غير صحيحة";
            return View();
        }

        // ===== TEST DATABASE =====
        public IActionResult TestDb()
        {
            try
            {
                var skillsCount = _context.Skills.Count(); // Query database
                return Content($"Database is working! Skills count: {skillsCount}");
            }
            catch (Exception ex)
            {
                return Content($"Database connection failed: {ex.Message}");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
