using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Movie.Web.Controllers
{using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;
    using Movie.Web.Models;

    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.Movies.Include(m => m.Company).Include(m => m.Director);
            return View(await movieContext.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Company)
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name");
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Duration,CreatedOn,CompanyId,DirectorId")] BindingMovie movie)
        {
            if (ModelState.IsValid)
            {
                //от BindingMovie movie правим Movie m
                Movie m = new Movie();
                m.Id = movie.Id;
                m.Name = movie.Name;
                m.Duration = movie.Duration;
                m.CreatedOn = movie.CreatedOn;
                m.DirectorId = movie.DirectorId;
                m.Director = _context.Directors.FirstOrDefault(x => x.Id == movie.DirectorId);
                m.CompanyId = movie.CompanyId;
                m.Company = _context.Companies.FirstOrDefault(x => x.Id == movie.CompanyId);

                _context.Add(m);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", movie.CompanyId);
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", movie.CompanyId);
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name", movie.DirectorId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Duration,CreatedOn,CompanyId,DirectorId")] BindingMovie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Movie m = new Movie();
                    m.Id = movie.Id;
                    m.Name = movie.Name;
                    m.Duration = movie.Duration;
                    m.CreatedOn = movie.CreatedOn;
                    m.DirectorId = movie.DirectorId;
                    m.Director = _context.Directors.FirstOrDefault(x => x.Id == movie.DirectorId);
                    m.CompanyId = movie.CompanyId;
                    m.Company = _context.Companies.FirstOrDefault(x => x.Id == movie.CompanyId);
                    _context.Update(m);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "Id", "Name", movie.CompanyId);
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "Name", movie.DirectorId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.Company)
                .Include(m => m.Director)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
