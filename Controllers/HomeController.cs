using Microsoft.AspNetCore.Mvc;

namespace LanceCerto.WebApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
