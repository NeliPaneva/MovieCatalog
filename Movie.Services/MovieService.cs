
namespace Movie.Services
{
    using Movie.Data;
    using Movie.Models;
    using System.Collections.Generic;

    public class MovieService : IMovieService
    {
        private MovieContext db;

        public MovieService(MovieContext db)
        {
            this.db = db;
        }
        public void Create(string name, int duration, string companyName, string directorName)
        {
            var movie = new Movie
            {
                Name = name,
                Duration = duration,
                CreatedOn = DateTime.UtcNow
            };

            //Company
            var companyEntity = db.Companies
                .FirstOrDefault(x => x.Name.Trim() == companyName.Trim());
            if (companyEntity == null)
            {
                companyEntity = new Company { Name = companyName };
            }
            movie.Company = companyEntity;

            //Director
            var derectorEntity = db.Directors
                .FirstOrDefault(x => x.Name.Trim() == directorName.Trim());
            if (derectorEntity == null)
            {
                derectorEntity = new Director { Name = directorName };
            }
            movie.Director = derectorEntity;

            this.db.Movies.Add(movie);
            this.db.SaveChanges();
        }

        public ICollection<string> GetAll()
        {
            var movies=db.Movies.ToList();
            var allMovies=new List<string>();
            foreach (var movie in movies)
            {
                string d = db.Directors.FirstOrDefault(x=>x.Id==movie.DirectorId).Name;
                string c = db.Companies.FirstOrDefault(x=>x.Id==movie.CompanyId).Name;
                string t = movie.CreatedOn.ToString();
                string m =$"{movie.Name}    {movie.Duration}    {t}    {d}    {c}";
                allMovies.Add(m);
            }
            return allMovies;
        }
    }
}
