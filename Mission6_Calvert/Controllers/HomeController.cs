using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Calvert.Models;

namespace Mission6_Calvert.Controllers
{
    public class HomeController : Controller
    {
        private AddMovieContext _context;
        public HomeController(AddMovieContext somename)
        {
            _context = somename;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Addmovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addmovie(MovieSubmission response)
        {
            _context.Submissions.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult AboutJoel()
        {
            return View();
        }
    }
}
