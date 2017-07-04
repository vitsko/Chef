namespace Salad
{
    public class Vegetable
    {
        private const int UnitOfWeigth = 100;

        internal string Name { get; private set; }
        internal string Color { get; private set; }
        internal int CaloriesByUnitWeigth { get; private set; }
        internal int Weight { get; private set; }
        internal int TotalCalories
        {
            get
            {
                return this.CaloriesByUnitWeigth * this.Weight / Vegetable.UnitOfWeigth;
            }
        }

        public Vegetable(string name, string color, int weight, int caloriesByUnitWeigth)
        {
            this.Name = name;
            this.Color = color;
            this.Weight = weight;
            this.CaloriesByUnitWeigth = caloriesByUnitWeigth;
        }

        public override string ToString()
        {
            return $"Name of vegetable is {this.Name}\nColor is {this.Color}\nWeight is {this.Weight} g.\nAmount of calories in {Vegetable.UnitOfWeigth} g. is {this.CaloriesByUnitWeigth}\nTotal calories is {this.TotalCalories}";
        }
    }
}