
namespace Movie.Data
{
    using Microsoft.EntityFrameworkCore;
    using Movie.Models;
    public class MovieContext : DbContext
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



            //Data Seeding - този процес позволява записване, наливане, вкарване на данни още при създаване
            //избирам Id  от 1, като първо пълня малките таблици и после филмите, които ползват данни Ид от малките
            //а за свързаните таблици ползвам малки Id-та за да съм сигурна, че вече има такива номера
            modelBuilder.Entity<Director>().HasData(
                new Director { Id=1,Name="James Kameron"},
                new Director { Id=2,Name="Steven Spilburg"},
                new Director { Id=3, Name="Kristpher Nolan"},
                new Director { Id=4, Name="Dgodge Lukas"},
                new Director { Id=5, Name= "Martin Campbell" });
            modelBuilder.Entity<Company>().HasData(
                new Director { Id = 1, Name = "Paramount" },
                new Director { Id = 2, Name = "TriStars" },
                new Director { Id = 3, Name = "Picsar" },
                new Director { Id = 4, Name = "Lucas films" },
                new Director { Id = 5, Name = "Universal" });
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, DirectorId = 1, Name = "Avatar", Duration = 130, CompanyId = 4, CreatedOn = new DateTime(2003, 12, 10) },
                new Movie { Id = 2, DirectorId = 2, Name = "E.T.", Duration = 150, CompanyId = 5, CreatedOn = new DateTime(1982, 3, 3) },
                new Movie { Id = 3, DirectorId = 1, Name = "Interstaller", Duration = 211, CompanyId = 1, CreatedOn = new DateTime(2003, 7, 22) },
                new Movie { Id = 4, DirectorId = 3, Name = "StarWors", Duration = 113, CompanyId = 4, CreatedOn = new DateTime(2013, 1, 12) },
                new Movie { Id = 5, DirectorId = 1, Name = "Zoro", Duration = 120, CompanyId = 3, CreatedOn = new DateTime(2023, 10, 12) }, 
                new Movie { Id = 6, DirectorId = 2, Name = "War of the worlds", Duration = 1450, CompanyId = 1, CreatedOn = new DateTime(2013, 11, 3) });
        }
    }
}
