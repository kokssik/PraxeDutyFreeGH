using DutyFreePraxe.DAL;
using DutyFreePraxe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DutyFreePraxe.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public OrderController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        // Bellow code for form integration:
        public IActionResult OrderList()
        {
                List<Models.Orders> arr = new List<Models.Orders>();

                using (var db = new StuffContext())
                {
                    var query = from b in db.orders
                                orderby b.OrderID
                                select b;

                    foreach (var item in query)
                    {
                            arr.Add(new Models.Orders { OrderID = item.OrderID, Name = item.Name, Price = item.Price, UserID = item.UserID, ProductID = item.ProductID });
                    }
                }
            return View(arr);
        }

        [HttpPost]
        public ActionResult Registration(Models.Orders p)
        {
            // here are the data
            using (var db = new StuffContext())
            {
                // TODO: add all fields
                var pro = new Models.Orders
                {
                    OrderID = p.OrderID,
                    Name = p.Name,
                    Price = p.Price,
                    UserID = p.UserID,
                    ProductID = p.ProductID
                };

                db.orders.Add(pro);
                db.SaveChanges(); // save changes to db

            }
            return RedirectToAction("MakeOrder", "Orders");
        }

        // [HttpPost]
        // public ActionResult Login(Models.Users p)
        // {
        //     // here are the data
        //     using (var db = new StuffContext())
        //     {
        //         var user = db.users.Single(h => h.Email == p.Email);
        //         Console.WriteLine(user.Email);
        //     }
        //     return RedirectToAction("Login", "Auth");
        // }


        public IActionResult MakeOrder()
        {
            return View();
        }

        public IActionResult AllOrders()
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