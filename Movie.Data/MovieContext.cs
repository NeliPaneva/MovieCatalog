
namespace Movie.Data
{  
    using Microsoft.EntityFrameworkCore;
    using Movie.Models;
    public class MovieContext:DbContext
    {
        public MovieContext()
        {
        }
        public MovieContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=MyMovieCatalog;Integrated Security=true;TrustServerCertificate=True");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //при изтриване на компания да се трие само ако няма филми направени от тази компания
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Movies)
                .WithOne(x => x.Company)
                .OnDelete(DeleteBehavior.Restrict);

          // този метод може и да го няма
        }
    }
}
