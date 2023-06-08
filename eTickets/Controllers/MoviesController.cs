using eTickets.Data;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace eTickets.Controllers
{
	public class MoviesController : Controller
	{
		private readonly AppDbContext _context;

		public MoviesController(AppDbContext context)
		{
			_context = context;
		}
		// GET: Movies
		public async Task<IActionResult> Index(string searchString)
		{
			if (_context.Movies == null)
			{
				return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
			}

			var movies = from m in _context.Movies.Include(m => m.Cinema)
						 select m;

			if (!string.IsNullOrEmpty(searchString))
			{
				movies = movies.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) || s.Description.ToLower().Contains(searchString.ToLower()));
			}

			return View(await movies.ToListAsync());
		}

	}
}
