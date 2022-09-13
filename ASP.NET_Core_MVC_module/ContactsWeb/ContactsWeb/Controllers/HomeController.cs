using ContactsWeb.Models;
using ContactsWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IContactManager _contactManager;

        public HomeController(ILogger<HomeController> logger, IContactManager contactManager)
        {
            _logger = logger;
            _contactManager = contactManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contactManager.GetAllContactsAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}