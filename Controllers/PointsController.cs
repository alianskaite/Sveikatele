using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using tp_sveikatele.Models;

namespace tp_sveikatele.Controllers
{
    public class PointsController : Controller
    {
        private const string FilePath = "sleepData.txt"; // Adjust the file path as needed

        // Action method to display total points
        public IActionResult Index()
        {
            var sleepList = LoadSleepListFromFile();
            int totalPoints = sleepList.Sum(s => s.Rating); // Calculate total points

            ViewBag.TotalPoints = totalPoints; // Pass total points to the view
            return View(); // Return the view to display total points
        }

        private List<SleepL> LoadSleepListFromFile()
        {
            var sleepList = new List<SleepL>();
            if (System.IO.File.Exists(FilePath))
            {
                var lines = System.IO.File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    sleepList.Add(new SleepL
                    {
                        Start = DateTime.Parse(parts[0], null, DateTimeStyles.RoundtripKind),
                        End = DateTime.Parse(parts[1], null, DateTimeStyles.RoundtripKind),
                        Rating = int.Parse(parts[2])
                    });
                }
            }
            return sleepList;
        }
    }
}
