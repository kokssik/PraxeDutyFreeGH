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

            return View(arr); // print the Products.cshtml + Shared
        }

        public IActionResult Insert()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Delete()
        {
            // string d = Request.Form["id"];
            int d = Int32.Parse(Request.Form["id"]);

            Console.WriteLine(d.ToString());

            using (var db = new StuffContext())
            {
                var result = db.products.SingleOrDefault(b => b.ProductID == d);
                if (result != null)
                {
                    result.IsDeleted = true;
                    db.SaveChanges();
                }
            }

            return Ok();
        }

        [HttpPost]
        public ActionResult Insert(Models.Products p)
        {
            // here are the data
            using (var db = new StuffContext())
            {
                // TODO: add all fields
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
            return RedirectToAction("Administration", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
