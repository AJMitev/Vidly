using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        public Rental(Customer customer, Movie movie)
        {
            this.Customer = customer;
            this.Movie = movie;
            this.DateRented = DateTime.Now;
        }

        public int Id { get; set; }

        [Required] 
        public Customer Customer { get; set; }

        [Required] 
        public Movie Movie { get; set; }
        
        public DateTime DateRented { get; set; }
        
        public DateTime? DateReturned { get; set; }
    }
}