using Microsoft.AspNetCore.Mvc;
using qcm_app.Models;
using System.Diagnostics;
using qcm_app.Data;

namespace qcm_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        // GET
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.email = HttpContext.Session.GetString("current_user");
            IEnumerable<Quiz> quizzes = _db.Quiz;
            return View(quizzes);
        }

        // POST
        [HttpPost]
        public IActionResult IndexP()
        {
            int id = Int32.Parse(Request.Form["quiz-select"]);

            if (id == 0 || _db.Quiz.Find(id) == null)
                return View();
            
            return RedirectToAction("Index", "Quiz", new { Id = id});
        }

    }
}