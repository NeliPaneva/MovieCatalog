using Movie.Data;

namespace Movie.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieContext db = new MovieContext();
            db.Database.EnsureCreated();
            
            
        }
    }
}
