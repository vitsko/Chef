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
        private List<object> vegetables,
                             distinctVegetables;

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
                    this.distinctVegetables = Salad.DistinctVegetables(value);

                    if (this.distinctVegetables.Count == 0 || this.distinctVegetables.Count < value.Count)
                    {
                        throw new NotDifferentVegetableException(Text.SameVegetable);
                    }

                    this.vegetables = value;
                }
                catch
                {
                    if (this.distinctVegetables.Count > 0)
                    {
                        this.vegetables = this.distinctVegetables;
                    }
                    else
                    {
                        this.vegetables = new List<object>();
                    }
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
                    sum += ((Vegetable)vegetable).TotalCalories;
                }
            }
            catch
            {
                return 0;
            }

            return sum;
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
                        builder.AppendLine(vegetable.ToString());
                    }

                    return builder.ToString();
                }
            }
            catch (InvalidOperationException ex)
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