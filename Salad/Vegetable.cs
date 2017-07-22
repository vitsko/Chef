namespace Salad
{
    using System;
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

        internal int TotalCalories
        {
            get
            {
                return this.CaloriesPerUnitWeigth * this.Weight / Vegetable.UnitOfWeigth;
            }
        }

        public override string ToString()
        {
            return $"Id = {this.Id}\nName of vegetable is {this.Name}\nColor is {this.Color}\nWeight is {this.Weight} g.\nAmount of calories in {Vegetable.UnitOfWeigth} g. is {this.CaloriesPerUnitWeigth}\nTotal calories is {this.TotalCalories}\n";
        }

        private static int GetID()
        {
            return countId++;
        }
    }
}