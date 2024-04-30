using Microsoft.AspNetCore.Mvc;
using tp_sveikatele.Models;
using tp_sveikatele.Repositories;

namespace tp_sveikatele.Controllers
{
    public class NutritionController : Controller
    {
        private readonly NutritionRepo _nutritionRepo;

        public NutritionController()
        {
            _nutritionRepo = new NutritionRepo();
        }

        [HttpGet]
        public ActionResult AddFood()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFood(Food model)
        {
            if (ModelState.IsValid)
            {
                var food = new Food
                {
                    Name = model.Name,
                    Calories = model.Calories,
                    Portion = model.Portion
                };

                _nutritionRepo.AddFood(food);

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Diary()
        {
            // Get all food items from the repository
            var foodItems = _nutritionRepo.GetAllFood();
            return View(foodItems);
        }
    }
}