using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Web.Models;
using System.Diagnostics;

namespace Movie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MovieContext _context;

        public HomeController(ILogger<HomeController> logger,MovieContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ActionResult> About()
        {
            IQueryable<MovieGroup> data =
                from movie in _context.Movies
                group movie by movie.Company.Name into dateGroup
                select new MovieGroup()
                {
                    CompanyName = dateGroup.Key,
                    MovieCount = dateGroup.Count()
                } ;
            data=data.OrderByDescending(x=>x.MovieCount);
            return View(await data.AsNoTracking().ToListAsync());
        }
    }
}
