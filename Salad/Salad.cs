namespace Salad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ArbitraryException;
    using Resource;

    public class Salad
    {
        private List<object> vegetables;

        public List<object> MixtureOfVegetables
        {
            get
            {
                return this.vegetables;
            }

            set
            {
                try
                {
                    Helper.SaladIsEmpty(value);

                    var distinctVegetables = Salad.DistinctVegetables(value);

                    if (distinctVegetables.Count < value.Count)
                    {
                        throw new NotDifferentVegetableException(Text.SameVegetable);
                    }

                    this.vegetables = value;
                }
                catch
                {
                    this.vegetables = new List<object>()
                    {
                        new Vegetable("Onion", "Green", 100, 40),
                        new Vegetable("Pepper", "Red", 200, 27),
                        new Vegetable("Pepper", "Yellow", 200, 27),
                        new Vegetable("Cabbage", "White", 150, 27),
                        new Vegetable("Cucumbers", "Green", 150, 16),
                        new Vegetable("Parsley", "Green", 100, 36),
                        new Vegetable("Radish", "Red", 250, 19)
                    };
                }
            }
        }

        public int GetTotalCalories()
        {
            int sum = 0;

            try
            {
                Helper.SaladIsEmpty(this.MixtureOfVegetables);

                foreach (var vegetable in this.MixtureOfVegetables)
                {
                    Helper.ObjectIsNotVegetable(vegetable);

                    sum += ((Vegetable)vegetable).TotalCalories;
                }
            }
            catch
            {
                sum = 0;
            }

            return sum;
        }

        public List<object> SortBy(Func<object, object> orderCriteria)
        {
            var isResult = Helper.IsResult(this.MixtureOfVegetables);

            return isResult ? this.MixtureOfVegetables.OrderBy(orderCriteria).ToList() :
                              new List<object>();
        }

        public List<object> Search(Func<object, bool> searchCriteria)
        {
            var isResult = Helper.IsResult(this.MixtureOfVegetables);

            return isResult ? this.MixtureOfVegetables.Where(searchCriteria).ToList() :
                              new List<object>();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            try
            {
                Helper.SaladIsEmpty(this.MixtureOfVegetables);

                if (this.MixtureOfVegetables.Count == 1)
                {
                    throw new OneVegetableExceptionException(string.Format(Text.OneVegetable, this.MixtureOfVegetables.ElementAt(0)));
                }
                else
                {
                    builder.AppendLine(Text.AboutVegetables);
                    builder.AppendLine();

                    foreach (var vegetable in this.MixtureOfVegetables)
                    {
                        Helper.ObjectIsNotVegetable(vegetable);

                        builder.AppendLine(vegetable.ToString());
                    }

                    return builder.ToString();
                }
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message;
            }
            catch (NullReferenceException ex)
            {
                return ex.Message;
            }
            catch (InvalidCastException ex)
            {
                return ex.Message;
            }
            catch (OneVegetableExceptionException ex)
            {
                return ex.Message;
            }
        }

        private static List<object> DistinctVegetables(List<object> salad)
        {
            var isResult = Helper.IsResult(salad);

            return isResult ? salad.Distinct(new DistinctVegetablesComparer()).ToList() :
                              new List<object>();
        }
    }
}