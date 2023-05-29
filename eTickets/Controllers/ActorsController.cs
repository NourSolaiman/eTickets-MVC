using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Actors/Create             
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

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);

        }

        //Get: Actors/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, FullName,ProfilePictureURL,Bio")] Actor actor)
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
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
