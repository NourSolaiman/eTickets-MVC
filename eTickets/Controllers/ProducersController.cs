using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
      /* //This is sync method,which means only one operation can be run at time
        public IActionResult Index()
        {
            var allProducers=_context.Producers.ToList();
            return View();
        } */
      
        //Async method,multi operation can run in parallel,we dont have to wait for response from DB
        public async Task<IActionResult> Index()
        {
            //Get all producers
            var allProducers = await _context.Producers.ToListAsync();
            return View();
        }

    }
}
