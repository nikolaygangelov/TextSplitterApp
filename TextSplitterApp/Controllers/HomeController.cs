using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextSplitterApp.Models;

namespace TextSplitterApp.Controllers
{
	/// <summary>
	/// HomeController inherits Controller class 
	/// gives you access to Request, Response, ViewBag, ViewData, View, etc.
	/// </summary>
	public class HomeController : Controller
	{
		/// <summary>
		/// value of _logger is passed by constructor
		/// _logger keeps record of errors
		/// using interface for best practices
		/// </summary>
		private readonly ILogger<HomeController> _logger;


		/// <summary>
		/// using dependancy injection through constructor
		/// </summary>
		/// <param name="logger"></param>
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}


		/// <summary>
		/// represents the result of an action method
		/// mapped to "Home/Index"
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		public IActionResult Index(TextViewModel model)
		{
			return View(model);
		}


		/// <summary>
		/// accepts a TextViewModel (from the view), then update it and pass it to the Index() method
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost] //sending data to server; action will be invoked on a "POST" request to "/Home/Split or /Split"
		public IActionResult Split(TextViewModel model)
		{
            //creating a new splitted text
            string[] splitTextArray = model
				.Text
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.ToArray();

			model.SplitText = string.Join(Environment.NewLine, splitTextArray);

			return RedirectToAction("Index", model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}