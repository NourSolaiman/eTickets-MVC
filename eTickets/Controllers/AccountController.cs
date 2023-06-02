using Azure.Identity;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


		public IActionResult Login(string returnURL)
		{
			return View(new Login
			{
				ReturnURL = returnURL ?? Url.Action("Index", "Movies")
			});
		}

		[HttpPost]
        public async Task<IActionResult> Login([Bind("UserName,Password")] Login login)
        {
            var validationContext = new ValidationContext(login);
            var validationResults = new List<ValidationResult>();

            bool isValidUserName = Validator.TryValidateProperty(login.UserName, new ValidationContext(login, null, null) { MemberName = "UserName" }, validationResults);
            bool isValidPassword = Validator.TryValidateProperty(login.Password, new ValidationContext(login, null, null) { MemberName = "Password" }, validationResults);

            bool isValidName = isValidUserName; // Add similar checks for other properties if needed
            bool isValidPass = isValidPassword;

            if (!isValidName || !isValidPass)
            {
                return View(login);
            }

            var user = await _userManager.FindByNameAsync(login.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        // Användaren är en admin, gör admin-specifika åtgärder här
                    }
                    else if (await _userManager.IsInRoleAsync(user, "User"))
                    {
                        // Användaren är en vanlig användare, gör användar-specifika åtgärder här
                    }

                    if (string.IsNullOrEmpty(login.ReturnURL))
                        return RedirectToAction("Index", "Movies");

                    return Redirect(login.ReturnURL);
                }
            }

            ModelState.AddModelError("", "Username/password not found");
            return View(login);
        }


        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserName,Password")] Login login)
        {
            var validationContext = new ValidationContext(login);
            var validationResults = new List<ValidationResult>();

            bool isValidUserName = Validator.TryValidateProperty(login.UserName, new ValidationContext(login, null, null) { MemberName = "UserName" }, validationResults);
            bool isValidPassword = Validator.TryValidateProperty(login.Password, new ValidationContext(login, null, null) { MemberName = "Password" }, validationResults);

            bool isValidName = isValidUserName; // Add similar checks for other properties if needed

            bool isValidPass = isValidPassword;

            if (isValidName && isValidPass)
            {


                var user = new IdentityUser(userName: login.UserName);
                var result = await _userManager.CreateAsync(
                    user: user, password: login.Password);
                if (result.Succeeded)
                {
					return RedirectToAction("LoggedIn");
				}
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", $"{err.Description}");
                    }
                }
            }
            return View(login);

        }

		public IActionResult LoggedIn()
		{
			return View();
		}


		public IActionResult Logout()
		{
			TempData["ReturnUrl"] = Request.Headers["Referer"].ToString();
			return View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutConfirmed()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}