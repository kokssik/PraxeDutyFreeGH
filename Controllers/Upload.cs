using DutyFreePraxe.DAL;
using DutyFreePraxe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DutyFreePraxe.Controllers
{
    public class UploadController : Controller
    {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        // public IActionResult UserList()
        // {
        //         List<Models.Users> arr = new List<Models.Users>();

        //         using (var db = new StuffContext())
        //         {
        //             var query = from b in db.users
        //                         orderby b.UserID
        //                         select b;

        //             foreach (var item in query)
        //             {
        //                     arr.Add(new Models.Users { UserID = item.UserID, Name = item.Name, ImageUrl = item.ImageUrl, Email = item.Email, Password = item.Password });
        //             }
        //         }
        //     return View(arr);
        // }

        [HttpPost]
        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
            {
                long size = files.Sum(f => f.Length);

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var filePath = Path.GetTempFileName();

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }

                // Process uploaded files
                // Don't rely on or trust the FileName property without validation.

                return Ok(new { count = files.Count, size });
            }


        public IActionResult Upload()
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