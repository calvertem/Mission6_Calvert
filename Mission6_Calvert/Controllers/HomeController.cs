using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", new MovieSubmission());
        }

        [HttpPost]
        public IActionResult Addmovie(MovieSubmission response)
        {
            if(ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
				ViewBag.Categories = _context.Categories
	                .OrderBy(x => x.CategoryName)
	                .ToList();
				return View(response);
            }
           
        }

        public IActionResult AboutJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movielist() 
            //linq - what we use to pull from the database in .net
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.MovieId)
                .ToList();

            return View(movies);

		}

		[HttpGet]
		public IActionResult Edit(int id)
        {
            var recordtoEdit = _context.Movies
                .Single(x => x.MovieId == id);

			ViewBag.Categories = _context.Categories
	            .OrderBy(x => x.CategoryName)
	            .ToList();

			return View("Addmovie", recordtoEdit);
        }

        [HttpPost]
		public IActionResult Edit(MovieSubmission updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Movielist");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {

            var recordtoDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordtoDelete);
        }

        [HttpPost]
        public IActionResult Delete(MovieSubmission application)
        {
            _context.Movies.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("Movielist");
        }
	}
}
