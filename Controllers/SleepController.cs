using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tp_sveikatele.Models;

namespace tp_sveikatele.Controllers
{
    public class SleepController : Controller
    {
        private const string FilePath = "sleepData.txt";

        [HttpPost]
        public IActionResult Create(DateTime start, DateTime end, int rating)
        {
            var newSleep = new SleepL
            {
                Start = start,
                End = end,
                Rating = rating
            };

            var sleepList = LoadSleepListFromFile();
            sleepList.Add(newSleep);
            SaveSleepListToFile(sleepList);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var sleepList = LoadSleepListFromFile();
            return View(sleepList);
        }

        [HttpGet]
        public IActionResult Edit(DateTime start, DateTime end)
        {
            var sleepList = LoadSleepListFromFile();
            var sleep = sleepList.FirstOrDefault(s => s.Start == start && s.End == end);
            if (sleep == null)
            {
                return NotFound();
            }
            return View(sleep);
        }

        [HttpPost]
        public IActionResult Edit(DateTime oldStart, DateTime oldEnd, DateTime start, DateTime end, int rating)
        {
            var sleepList = LoadSleepListFromFile();
            var sleep = sleepList.FirstOrDefault(s => s.Start == oldStart && s.End == oldEnd);
            if (sleep == null)
            {
                return NotFound();
            }

            sleep.Start = start;
            sleep.End = end;
            sleep.Rating = rating;
            SaveSleepListToFile(sleepList);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(DateTime start, DateTime end)
        {
            var sleepList = LoadSleepListFromFile();
            var sleep = sleepList.FirstOrDefault(s => s.Start == start && s.End == end);
            if (sleep == null)
            {
                return NotFound();
            }

            sleepList.Remove(sleep);
            SaveSleepListToFile(sleepList);

            return RedirectToAction("Index");
        }

        private void SaveSleepListToFile(List<SleepL> sleepList)
        {
            var lines = sleepList.Select(sleep => $"{sleep.Start:O}|{sleep.End:O}|{sleep.Rating}");
            System.IO.File.WriteAllLines(FilePath, lines);
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
