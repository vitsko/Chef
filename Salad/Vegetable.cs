namespace Salad
{
    public class Vegetable
    {
        private const int UnitOfWeigth = 100;
        private static int countId = 1;

        public Vegetable(string name, string color, int weight, int caloriesByUnitWeigth)
        {
            this.Id = Vegetable.GetID();
            this.Name = name;
            this.Color = color;
            this.Weight = weight;
            this.CaloriesPerUnitWeigth = caloriesByUnitWeigth;
        }

        public string Color
        {
            get;
            private set;
        }

        public int CaloriesPerUnitWeigth
        {
            get;
            private set;
        }

        internal int Id
        {
            get;
            private set;
        }

        internal string Name
        {
            get;
            private set;
        }

        internal int Weight
        {
            get;
            private set;
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