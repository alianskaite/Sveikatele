using System.Collections.Generic;
using tp_sveikatele.Models;

namespace tp_sveikatele.Repositories
{
    public class NutritionRepo
    {
        private static List<Food> _foodList = new List<Food>();

        public void AddFood(Food food)
        {
            _foodList.Add(food);
        }

        public IEnumerable<Food> GetAllFood()
        {
            return _foodList;
        }
    }
}