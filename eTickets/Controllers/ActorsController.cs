using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        //Injecting IActorsService,becouse we have decide to move DbContext from Controlers to the ActorsService
        private readonly IActorsService _service; //first we have to introduce/declare IActorService

        //In order to use IActorsService we have to create constructor and inject IActorService

        public ActorsController(IActorsService service)
        {
            _service = service; //assign the value
        }
        public async Task <IActionResult> Index()
        {
            //get data
            var data =await _service.GetAll();  
            return View(data);
        }
    }
}
