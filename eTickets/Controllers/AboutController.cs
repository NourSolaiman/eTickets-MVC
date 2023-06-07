using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
