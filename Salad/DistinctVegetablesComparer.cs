namespace Salad
{
    using System.Collections.Generic;

    internal class DistinctVegetablesComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            return ((Vegetable)x).Color == ((Vegetable)y).Color &&
                   ((Vegetable)x).Name == ((Vegetable)y).Name &&
                   ((Vegetable)x).Weight == ((Vegetable)y).Weight &&
                   ((Vegetable)x).CaloriesPerUnitWeigth == ((Vegetable)y).CaloriesPerUnitWeigth;
        }

        public int GetHashCode(object obj)
        {
            return ((Vegetable)obj).Color.GetHashCode() ^
                   ((Vegetable)obj).Name.GetHashCode() ^
                   ((Vegetable)obj).Weight.GetHashCode() ^
                   ((Vegetable)obj).CaloriesPerUnitWeigth.GetHashCode();
        }
    }
}