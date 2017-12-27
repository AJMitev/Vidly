using System.Linq;
using System.Web.Http;
using Vidly.Database;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private readonly DbContext _context;

        public NewRentalController()
        {
            _context = new DbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No movie ids have been given");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
            if (customer == null)
                return BadRequest("Invalid Customer");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or moveMovieIds are invalid");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("This movie is not avaliable");

                movie.NumberAvailable--;
                var rental = new Rental(customer, movie);
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
