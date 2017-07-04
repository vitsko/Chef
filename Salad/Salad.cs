namespace Salad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salad
    {
        private List<Vegetable> salad = Data.GetVegetablesForSalad();

        public int GetTotalCalories()
        {
            int sum = 0;

            foreach (var vegetable in salad)
            {
                sum += vegetable.TotalCalories;
            }

            return sum;
        }

        public List<Vegetable> SortBy(Func<Vegetable, object> orderCriteria)
        {
            return salad.OrderBy(orderCriteria).ToList();
        }

        public List<Vegetable> Search(Func<Vegetable, bool> searchCriteria)
        {
            return salad.Where(searchCriteria).ToList();
        }
    }
}