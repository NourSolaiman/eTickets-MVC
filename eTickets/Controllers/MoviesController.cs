using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    { 
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _context.Movies.Include(n=>n.Cinema).OrderBy(n=>n.Name).ToListAsync(); //we are including Cinema becouse we want to display Cinema prop in Movies View
            return View(allMovies);
        }
    }
}
