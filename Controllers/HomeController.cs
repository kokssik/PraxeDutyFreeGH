using DutyFreePraxe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DutyFreePraxe.DAL;

namespace DutyFreePraxe.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
                                List<Models.Products> arr = new List<Models.Products>();

                                using (var db = new StuffContext())
                                {
                                    var query = from b in db.products
                                                orderby b.ProductID
                                                select b;

                                    foreach (var item in query)
                                    {
                                        // Console.WriteLine(item.Name);
                                        // TODO: add all fields
                                        if (item.IsDeleted != true)
                                            arr.Add(new Models.Products { ProductID = item.ProductID, Name = item.Name, ImageUrl = item.ImageUrl, Price = item.Price, Quantity = item.Quantity });
                                    }
                                }
            return View(arr);
        }

        public IActionResult Privacy()
        {
            // return Content("Hello, MVC world!");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}