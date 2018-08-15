using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly MvcMovieContext _db;
        public HomeController(MvcMovieContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "This is description change.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Display()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Display(Movie movie)
        {
            _db.Movie.Update(movie);
            _db.SaveChanges();
            return View(movie);
        }

        public IActionResult AllMovies()
        {
            var movies = _db.Movie.AsQueryable().ToList();
            return View(movies);
        }

        public IActionResult Update(Movie m)
        {
            var movie = _db.Movie.Find(m.ID);
            movie.Price = m.Price;
            movie.Title = m.Title;
            _db.SaveChanges();
            return View();
        }

        public IActionResult Edit(int ID)
        {
            var movie = _db.Movie.Find(ID);
            return View("Display", movie);
        }
    }
}
