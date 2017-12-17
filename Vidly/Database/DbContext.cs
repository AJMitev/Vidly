using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Vidly.Models;

namespace Vidly.Database
{
    public class DbContext : IdentityDbContext<User>
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DbContext Create()
        {
            return new DbContext();
        }
    }
}