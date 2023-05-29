using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

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
            var data =await _service.GetAllAsync();  
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
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {            
            var validationContext = new ValidationContext(actor);
            var validationResults = new List<ValidationResult>();

            bool isValidProfilePictureURL = Validator.TryValidateProperty(actor.ProfilePictureURL, new ValidationContext(actor, null, null) { MemberName = "ProfilePictureURL" }, validationResults);
            bool isValidFullName = Validator.TryValidateProperty(actor.FullName, new ValidationContext(actor, null, null) { MemberName = "FullName" }, validationResults);
            bool isValidBio = Validator.TryValidateProperty(actor.Bio, new ValidationContext(actor, null, null) { MemberName = "Bio" }, validationResults);

            bool isValidName = isValidFullName; // Add similar checks for other properties if needed
            bool isValidPictureURL = isValidProfilePictureURL;
            bool isValidBiography = isValidBio;

            if (!isValidName || !isValidPictureURL || !isValidBiography)
            {
                return View(actor);
            }
           await _service.AddAsync(actor);// adding actor to Db
            return RedirectToAction(nameof(Index));

        } 

        //Get: Actors/Details/ by Id
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails=await _service.GetByIdAsync(id);

            if (actorDetails==null)
            {
                return View("Not Found");
            }
            else 
            {
                return View(actorDetails); 
            }
            
            
              

        }
       
    }
}
