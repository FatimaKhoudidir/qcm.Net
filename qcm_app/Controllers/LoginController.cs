using Microsoft.AspNetCore.Mvc;
using qcm_app.Data;
using qcm_app.Models;
using System.Text.Json;

namespace qcm_app.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LoginController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // POST
        [HttpPost, ActionName("Index")]
        public IActionResult SignIn(User user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            User dbUser = _db.User.First(u => u.Email == user.Email);
            if(dbUser == null && dbUser.Password == user.Password)
            {
                ModelState.AddModelError("Password", "Invalid information");
                return View(user);
            }
            HttpContext.Session.SetString("current_user", dbUser.Email);
            return RedirectToAction("Index", "Home");
        }

        // GET
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }
            try
            {
                _db.User.Add(user);
                _db.SaveChanges();
            }catch(Exception e)
            {
                ModelState.AddModelError("Password", "error");
                return View(user);
            }
            HttpContext.Session.SetString("current_user", user.Email);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("current_user");
            return RedirectToAction("Index", "Login");
        }
    }
}
