using System;
using System.Linq;
using System.Web.Mvc;
using Vidly.Database;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using DbContext = Vidly.Database.DbContext;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly DbContext _context;

        public MovieController()
        {
            _context = new DbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var viewModel = new MovieFormViewModel { Genres = _context.Genres.ToList(), Movie = new Movie() };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel { Genres = _context.Genres.ToList(), Movie = movie };

                return View("Create", viewModel);
            }

            using (var db = _context)
            {

                db.Movies.Add(movie);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Movie");
        }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var currentMovie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (currentMovie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = currentMovie,
                Genres = _context.Genres.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MovieFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel {Movie = model.Movie, Genres = _context.Genres.ToList()};

                return View("Edit", viewModel);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == model.Movie.Id);

            if (movieInDb == null)
            {
                return HttpNotFound(); 
            }

            using (var db = _context)
            {
                movieInDb.Name = model.Movie.Name;
                movieInDb.GenreId = model.Movie.GenreId;
                movieInDb.ReleaseDate = model.Movie.ReleaseDate;
                movieInDb.NumberInStock = model.Movie.NumberInStock;

                db.SaveChanges();
            }

            return RedirectToAction("Index","Movie");
        }
    }
}