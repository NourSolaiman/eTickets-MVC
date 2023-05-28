using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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

        //Get: Actors/Create , Becouse we dont have any data manipulation we are going to use sync method
        public IActionResult Create()
        {
            return View();
        }

        //Creating Post request for sending data to Db,becouse we have 4 prop i Actor Model
        // and 3 in our create form we have to bind them together with help of [Bind(" ")]

        [HttpPost]
        //ModelState.IsValid is checking if required prop are filled in
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);// we are returning same view but with actor data
            }
            _service.Add(actor);// adding actor to Db
            return RedirectToAction(nameof(Index));//after actor is added to Db we are redirect to the name of Index
            
        } 

    }
}
