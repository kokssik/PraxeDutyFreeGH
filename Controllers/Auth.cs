using DutyFreePraxe.DAL;
using DutyFreePraxe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DutyFreePraxe.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        // Bellow code for form integration:
        public IActionResult Index()
        {
                List<Models.Users> arr = new List<Models.Users>();

                using (var db = new StuffContext())
                {
                    var query = from b in db.users
                                orderby b.UserID
                                select b;

                    foreach (var item in query)
                    {
                            arr.Add(new Models.Users { UserID = item.UserID, Name = item.Name, ImageUrl = item.ImageUrl, Email = item.Email, Password = item.Password });
                    }
                }
            return View(arr);
        }




        public IActionResult Login()
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