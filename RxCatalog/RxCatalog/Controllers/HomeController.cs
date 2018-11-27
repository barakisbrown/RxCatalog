using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RxCatalog.Models;

namespace RxCatalog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var recordCount = 0;
            using (var db = new ItemContext())
            {
                recordCount = db.Items.Count();
            }
            var contentString = $"<h2>There are {recordCount} records in the database</h2>";
            return Content(contentString);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
