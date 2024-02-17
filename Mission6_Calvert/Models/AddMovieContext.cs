using Microsoft.EntityFrameworkCore;

namespace Mission6_Calvert.Models
{
    public class AddMovieContext : DbContext
    {
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base (options)
        {
        }

        public DbSet<MovieSubmission> Submissions { get; set; }
    }
}
