using DutyFreePraxe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DutyFreePraxe.DAL;

namespace DutyFreePraxe.Controllers
{
    public class AdminController : Controller
    {

        // this variable has the data for the page called Products.cshtml
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        // this function returns the HTML for the page called Products.cshtml
        public IActionResult Administration()
        {
            List<Models.Products> arr = new List<Models.Products>();

            using (var db = new StuffContext())
            {
                var query = from b in db.products
                            orderby b.Name
                            select b;

                foreach (var item in query)
                {
                    // Console.WriteLine(item.Name);
                    arr.Add(new Models.Products { Name = item.Name, ImageUrl = item.ImageUrl, Price = item.Price, Quantity = item.Quantity });
                }
            }

            return View(arr); // print the Products.cshtml + Shared
        }

        public IActionResult Insert(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Models.Products p)
        {
            // here are the data
            using (var db = new StuffContext())
            {
                var pro = new Models.Products
                {
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Quantity = p.Quantity
                };

                db.products.Add(pro);
                db.SaveChanges(); // save changes to db

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}