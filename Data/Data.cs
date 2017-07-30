namespace Data
{
    using System.Collections.Generic;
    using Salad;

    public static class Data
    {
        public static List<object> GetVegetablesForSalad()
        {
            List<object> salad = new List<object>()
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

        public static List<object> GetSameVegetablesOnly()
        {
            List<object> salad = new List<object>()
            {
                new Vegetable("Onion", "Green", 100, 40),
                new Vegetable("Onion", "Green", 100, 40),
                new Vegetable("Onion", "Green", 100, 40)
            };

            return salad;
        }

        public static List<object> GetVegetablesWithNull()
        {
            List<object> salad = new List<object>()
            {
                new Vegetable("Onion", "Green", 100, 40),
                new Vegetable("Pepper", "Red", 200, 27),
               null
            };

            return salad;
        }

        public static List<object> GetVegetablesWithAnotherObject()
        {
            List<object> salad = new List<object>()
            {
                new Vegetable("Onion", "Green", 100, 40),
                new object(),
                new Vegetable("Pepper", "Red", 200, 27)
            };

            return salad;
        }

        public static List<object> GetAllIsNotVegetables()
        {
            List<object> salad = new List<object>()
            {
                new object(),
                null,
                new object()
            };

            return salad;
        }

        public static List<object> GetVegetablesForCheckSaladToString()
        {
            List<object> salad = new List<object>()
            {
                new Vegetable("Onion", "Green", 100, 40),
                new Vegetable("Pepper", "Red", 200, 27)
            };

            return salad;
        }
    }
}