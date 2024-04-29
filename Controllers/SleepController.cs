using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using tp_sveikatele.Models;
using tp_sveikatele.Repositories;

namespace tp_sveikatele.Controllers
{
    public class SleepController : Controller
    {
        // In-memory collections to store posts and comments
        private static List<SleepL> sleepData = new List<SleepL>();

        public IActionResult Index()
        {
            // Retrieve posts with their associated comments
            var sleep = SleepRepo.List();
            return View(sleep);
        }
    }
}
