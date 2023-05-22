using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        //inject Dbcontext file,we use context file to send or get data from DB
        //each controller must have DbContext file
        private readonly AppDbContext _context; //first we have to declare AppDbContext

        //In order to use DbContext we have to create constructor and inject DbContext

        public ActorsController(AppDbContext context)
        {
            _context = context; //assign the value
        }
        public IActionResult Index()
        {
            //get data
            var data=_context.Actors.ToList();  
            return View(data);
        }
    }
}
