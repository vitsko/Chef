namespace Salad
{
    using System.Collections.Generic;

    internal static class Data
    {
        internal static List<Vegetable> GetVegetablesForSalad()
        {
            List<Vegetable> salad = new List<Vegetable>()
            {
                new Vegetable("Onion", "Green", 100, 40),
                new Vegetable("Pepper", "Red", 200, 27),
                new Vegetable("Pepper", "Yellow", 200, 27),
                new Vegetable("Cabbage", "White", 150, 27),
                new Vegetable("Cucumbers", "Green", 150, 16),
                new Vegetable("Parsley", "Green", 100, 36),
                new Vegetable("Radish", "Red", 250, 19)
            };

            return salad;
        }
    }
}