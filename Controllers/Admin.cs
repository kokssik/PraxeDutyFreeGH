using DutyFreePraxe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DutyFreePraxe.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        // this function returns the HTML for the page called Products.cshtml
        public IActionResult Administration()
        {

            // this variable has the data for the page called Products.cshtml
            List<Models.Products> arr = new List<Models.Products>() {
                new Models.Products {Name = "Anticol", ImageUrl = "https://images-ext-1.discordapp.net/external/lwFBBFEhAoiQ67cOOeMP5BCMkZ2vXE70Bif8G6c3Y10/https/lekarnacz.vshcdn.net/upload/an/ti/anticol-extra-strong-50g-3211-1945720-350x350-square.jpg", Price=10, Quantity=0} ,
                new Models.Products {Name = "Birell", ImageUrl = "https://images-ext-1.discordapp.net/external/GsTg2VeLWxDQBbfjaNPfHxYyP7wk2mQ2qibs59JD0YM/https/secure.ce-tescoassets.com/assets/CZ/302/8594404001302/ShotType1_540x540.jpg", Price=5, Quantity=5} ,
            };

            return View(arr); // print the Products.cshtml + Shared
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}