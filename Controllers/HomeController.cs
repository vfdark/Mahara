using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mahara.Models;

namespace Mahara.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // ===== LOGIN PAGE =====
        // GET: Display login form
        public IActionResult Login()
        {
            return View();
        }

        // POST: Handle login form submission
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            // Simple example: replace with your real authentication logic
            if (Email == "test@test.com" && Password == "123456")
            {
                // You can store user info in session or cookie here
                return RedirectToAction("Index"); // Redirect to home page on success
            }
            else
            {
                ViewBag.Error = "البريد الإلكتروني أو كلمة المرور غير صحيحة";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
