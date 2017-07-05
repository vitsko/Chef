namespace Salad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salad
    {
        private List<Vegetable> mixture;

        public List<Vegetable> MixtureOfVegetables
        {
            get
            {
                if (this.mixture == null)
                {
                    this.mixture = Data.GetVegetablesForSalad();
                }

                return this.mixture;
            }
        }

        public int GetTotalCalories()
        {
            int sum = 0;

            foreach (var vegetable in this.MixtureOfVegetables)
            {
                sum += vegetable.TotalCalories;
            }

            return sum;
        }

        public List<Vegetable> SortBy(Func<Vegetable, object> orderCriteria)
        {
            return this.MixtureOfVegetables.OrderBy(orderCriteria).ToList();
        }

        public List<Vegetable> Search(Func<Vegetable, bool> searchCriteria)
        {
            return this.MixtureOfVegetables.Where(searchCriteria).ToList();
        }
    }
}