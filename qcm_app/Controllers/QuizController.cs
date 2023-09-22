using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using qcm_app.Data;
using qcm_app.Models;
using static System.Net.Mime.MediaTypeNames;

namespace qcm_app.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuizController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index(int id)
        {
            Quiz quiz = _db.Quiz.Find(id);
            ViewBag.quiz = quiz;
            IQueryable<QuesVM> questions = _db.Questions.Where(q => q.Quiz_Id == id)
                .Select(q => new QuesVM
                {
                    Question_Id = q.Id,
                    Question_Text = q.Text,
                    Choices = _db.Choice.Where(c => c.Question_Id == q.Id).Select(
                        c => new Choice
                        {
                            Id = c.Id,
                            Text = c.Text,
                            isAnswer = c.isAnswer,
                            Question_Id = c.Question_Id
                        }).ToList()
                }); ;
            HttpContext.Session.SetInt32("Quiz_Id", id);
            return View(questions);
        }

        // POST
        [HttpPost]
        public IActionResult Result(List<string> answer)
        {
            int n = 0;
            foreach(string s in answer)
            {
                int id = Int32.Parse(s);
                if(id == 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                Choice choice = _db.Choice.Where(c => c.Id == id)
                    .Select(c => new Choice
                    {
                        Id = c.Id,
                        Text = c.Text,
                        Question_Id = c.Question_Id,
                        isAnswer = c.isAnswer
                    }).First();

                if(choice == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                if(choice.isAnswer)
                {
                    n++;
                }
            }

            int quiz_id = (int)HttpContext.Session.GetInt32("Quiz_Id");
            int nbr = _db.Questions.Where(q => q.Quiz_Id == quiz_id).Count();

            ViewBag.rs = n + " / " + nbr;
            return View();
        }
     
        // GET
        public IActionResult Cancel()
        {
            return RedirectToAction("Index", "Home");
        }


    }
}
