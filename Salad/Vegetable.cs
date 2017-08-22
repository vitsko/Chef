namespace Salad
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ArbitraryException;
    using Resource;

    public class Vegetable
    {
        private const int UnitOfWeigth = 100,
                         CaloriesDefault = 50,
                         WeigthDefault = 100;

        private static int countId = 1;

        private string color,
                       name;

        private int caloriesPerUnitWeigth,
                    weight;

        public Vegetable(string name, string color, int weight, int caloriesPerUnitWeigth)
        {
            this.Id = Vegetable.GetID();
            this.Name = name;
            this.Color = color;
            this.Weight = weight;
            this.CaloriesPerUnitWeigth = caloriesPerUnitWeigth;
        }

        public string Color
        {
            get
            {
                return this.color;
            }

            private set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException(Text.ColorIsUndefined);
                    }
                    else
                    {
                        this.color = value;
                    }
                }
                catch
                {
                    this.color = Text.ColorOfVegetable;
                }
            }
        }

        public int CaloriesPerUnitWeigth
        {
            get
            {
                return this.caloriesPerUnitWeigth;
            }

            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new NotExistCaloriesException();
                    }
                    else
                    {
                        this.caloriesPerUnitWeigth = value;
                    }
                }
                catch
                {
                    this.caloriesPerUnitWeigth = Vegetable.CaloriesDefault;
                }
            }
        }

        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException(Text.NameIsUndefined);
                    }
                    else
                    {
                        this.name = value;
                    }
                }
                catch
                {
                    this.name = Text.NameOfVegetable;
                }
            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }

            private set
            {
                try
                {
                    if (value <= 0)
                    {
                        throw new NotExistCaloriesException();
                    }
                    else
                    {
                        this.weight = value;
                    }
                }
                catch
                {
                    this.weight = Vegetable.WeigthDefault;
                }
            }
        }

        public int TotalCalories
        {
            get
            {
                return this.CaloriesPerUnitWeigth * this.Weight / Vegetable.UnitOfWeigth;
            }
        }

        public Dictionary<string, string> TitleasAndValuesOfVegetable
        {
            get
            {
                Dictionary<string, string> titleasAndValuesOfVegetable = new Dictionary<string, string>();

                titleasAndValuesOfVegetable.Add(Text.Name, this.Name);
                titleasAndValuesOfVegetable.Add(Text.Color, this.Color);
                titleasAndValuesOfVegetable.Add(Text.Weight, this.Weight.ToString());
                titleasAndValuesOfVegetable.Add(string.Format(Text.CaloriesPerUnitWeigth, Vegetable.UnitOfWeigth.ToString()), this.CaloriesPerUnitWeigth.ToString());
                titleasAndValuesOfVegetable.Add(Text.TotalCalories, this.TotalCalories.ToString());

                return titleasAndValuesOfVegetable;
            }
        }

        public override string ToString()
        {
            StringBuilder allinfo = new StringBuilder();

            allinfo.AppendLine(Text.Id);
            allinfo.AppendLine(this.Id.ToString());

            foreach (var item in this.TitleasAndValuesOfVegetable)
            {
                allinfo.AppendLine(item.Key);
                allinfo.AppendLine(item.Value);
            }

            return allinfo.ToString();
        }

        internal virtual string GetInfoToSave()
        {
            StringBuilder toSave = new StringBuilder();

            foreach (var item in this.TitleasAndValuesOfVegetable)
            {
                if (!item.Key.Equals(Text.TotalCalories))
                {
                    toSave.Append(item.Key);
                    toSave.Append(item.Value);
                    toSave.Append(Text.Sharp);
                }
            }

            return toSave.ToString();
        }

        private static int GetID()
        {
            return countId++;
        }
    }
}